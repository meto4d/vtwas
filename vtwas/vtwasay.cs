using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Net;
using System.Windows;
using System.Net.Http;
using System.Web;
using Microsoft.VisualBasic.Devices;

namespace vtwas
{
    // vtwas本体

    public class vtwasay
    {

        // ソフト　プロパティ
        static public string AppName = "vtwas";
        static public string Version = "0.0.1";
        static public string Author = "Ruth@meto4d";
        static public string GitURL = "https://github.com/meto4d/vtwas";


        // Formからのオプション

        public struct FORM
        {
            /// <summary>
            /// 前回終了時のウインドウ表示位置X
            /// </summary>
            public int X;
            /// <summary>
            /// 前回終了時のウインドウ表示位置Y
            /// </summary>
            public int Y;
            /// <summary>
            /// 前回終了時のウインドウ幅W
            /// </summary>
            public int W; // 幅固定
            /// <summary>
            /// 前回終了時のウインドウ高H
            /// </summary>
            public int H;
        }
        static public FORM form;

        static public string url;
        static public string key;
        static public string pass;
        static public string charcode;
        static public bool enableclip;

        // パラメータ用構造体
        // HttpUtility.UrlEncodeとUri.EscapeDataStringが混じってキモい感ある
        // HttpUtility.UrlEncode → URLにエンコードする用
        // Uri.EscapeDataString → 設定ファイルに保存する用
        public struct Params {
            public string param;
            public string text;

            public override string ToString()
            {
                
                return Uri.EscapeDataString(param) + "," + Uri.EscapeDataString(text);
            }

            public string ToUriParam(Encoding e)
            {
                return param + "=" + HttpUtility.UrlEncode(text, e);
            }

            public bool ContainText()
            {
                if (this.param == "" && this.text == "") return false;
                else return true;
            }
        };
        static public Params SetParams(string str)
        {
            Params par;
            string[] strs = str.Split(',');
            par.param = Uri.UnescapeDataString(strs.Length < 1 ? "" : strs[0]);
            par.text  = Uri.UnescapeDataString(strs.Length < 2 ? "" : strs[1]);

            return par;
        }
        
        static public List<Params> param_list;

        // ベーシック認証関係
        static private SecurityProtocolType sptype = 
            SecurityProtocolType.Tls
                | SecurityProtocolType.Tls11
                | SecurityProtocolType.Tls12
                | SecurityProtocolType.Ssl3;

        static private string author_encoded;

        // エンコード
        static private Encoding encode;

        // パラメータ付きURL
        static private string paramUrl;

        // 音声データ関係
        static private byte[] vs;
        static private Audio audio = new Audio();

        // クリップボード関係
        static private IDataObject clipboardObj;

        public vtwasay()
        {

        }

        #region INI設定
        // 設定の読み出し
        static public void LoadSetting()
        {

            string iniFile = System.Windows.Forms.Application.StartupPath + "/setting.ini";
            StringBuilder sb = new StringBuilder(1024);


            #region ウィンドウの位置・サイズ
            int x = 100;
            int y = 100;
            int w = 470;
            int h = 240;
            IniFileHandler.GetPrivateProfileString("FORM", "X", x.ToString(), sb, (uint)sb.Capacity, iniFile); try { form.X = int.Parse(sb.ToString()); } catch { form.X = 100; }
            IniFileHandler.GetPrivateProfileString("FORM", "Y", y.ToString(), sb, (uint)sb.Capacity, iniFile); try { form.Y = int.Parse(sb.ToString()); } catch { form.Y = 100; }
            IniFileHandler.GetPrivateProfileString("FORM", "W", w.ToString(), sb, (uint)sb.Capacity, iniFile); try { form.W = int.Parse(sb.ToString()); } catch { form.W = 470; }
            IniFileHandler.GetPrivateProfileString("FORM", "H", h.ToString(), sb, (uint)sb.Capacity, iniFile); try { form.H = int.Parse(sb.ToString()); } catch { form.H = 240; }
            #endregion

            IniFileHandler.GetPrivateProfileString("URL", "URL", "", sb, (uint)sb.Capacity, iniFile);
            url = sb.ToString();

            IniFileHandler.GetPrivateProfileString("Token", "Key", "", sb, (uint)sb.Capacity, iniFile);
            key = sb.ToString();

            IniFileHandler.GetPrivateProfileString("Token", "Pass", "", sb, (uint)sb.Capacity, iniFile);
            pass = sb.ToString();
            //pass = pass; // decode

            IniFileHandler.GetPrivateProfileString("Param", "CharCode", "", sb, (uint)sb.Capacity, iniFile);
            charcode = sb.ToString();

            enableclip = IniFileHandler.GetPrivateProfileInt("Param", "EnableClip", 0, iniFile) != 0 ? true : false;

            int listCount = (int)IniFileHandler.GetPrivateProfileInt("Param", "ListCount", 0, iniFile);
            param_list = new List<Params>();
            for(int index = 0; index < listCount; index++)
            {
                IniFileHandler.GetPrivateProfileString("Param", "List" + index.ToString(), "", sb, (uint)sb.Capacity, iniFile);
                param_list.Add(SetParams(sb.ToString()));
            }

#if DEBUG
            for (int index = listCount; index < listCount + 5; index++)
            {
                IniFileHandler.GetPrivateProfileString("Param", "List" + index.ToString(), "", sb, (uint)sb.Capacity, iniFile);
                if (sb.ToString() != "")
                {
                    param_list.Add(SetParams(sb.ToString()));
                }
            }
#endif

            PostSettingChanged();
        }

        // 設定の書き出し
        static public void SaveSetting()
        {

            string iniFile = System.Windows.Forms.Application.StartupPath + "/setting.ini";

            string str = "";

            IniFileHandler.WritePrivateProfileString("URL", "URL", url, iniFile);
            IniFileHandler.WritePrivateProfileString("Token", "Key", key, iniFile);

            // pass encode
            str = pass;
            IniFileHandler.WritePrivateProfileString("Token", "Pass", str, iniFile);


            IniFileHandler.WritePrivateProfileString("Param", "CharCode", charcode, iniFile);

            str = enableclip ? "1" : "0";
            IniFileHandler.WritePrivateProfileString("Param", "EnableClip", str, iniFile);

            int count = 0;
            IniFileHandler.WritePrivateProfileString("Param", "ListCount", count.ToString(), iniFile);

            foreach(var par in param_list)
            {
                if(par.ContainText())
                {
                    IniFileHandler.WritePrivateProfileString("Param", "List"+ count.ToString(), par.ToString(), iniFile);

                    count++;
                }
            }
            IniFileHandler.WritePrivateProfileString("Param", "ListCount", count.ToString(), iniFile);


            #region ウィンドウの位置・サイズ
            IniFileHandler.WritePrivateProfileString("FORM", "X", form.X.ToString(), iniFile);
            IniFileHandler.WritePrivateProfileString("FORM", "Y", form.Y.ToString(), iniFile);
            //IniFileHandler.WritePrivateProfileString("FORM", "W", form.W.ToString(), iniFile);
            IniFileHandler.WritePrivateProfileString("FORM", "H", form.H.ToString(), iniFile);
            #endregion


            PostSettingChanged();
        }

        #endregion

        // パラメータ変更時
        static private void PostSettingChanged()
        {
            encode = encoding();
            author_encoded = AuthorEncode();
            paramUrl = ParamUrlTst();
        }

        //エンコード
        static private Encoding encoding()
        {
            Encoding e;
            switch(charcode)
            {
                case "UTF-8":
                    e = Encoding.UTF8;
                    break;
                case "ShiftJIS":
                    e = Encoding.GetEncoding("shift_jis");
                    break;
                case "EUC-JP":
                    e = Encoding.GetEncoding("euc-jp");
                    break;



                default:
                    e = Encoding.UTF8;
                    break;
            }

            return e;
        }

        // Basic認証エンコード
        static private string AuthorEncode()
        {
            return System.Convert.ToBase64String(encode.GetBytes(key + ":" + pass));
        }

        static private string ParamUrlTst()
        {
            // URLセット
            string paramurl = url;

            // 初回パラメータ用
            bool firstParam = true;

            // パラメータ設定
            // なるべく上から処理するようにしたい
            for (int index = 0; index < param_list.Count; index++)
            {
                if (!param_list[index].ContainText()) continue;

                // 初回のパラーメタ
                paramurl += firstParam ? "?" : "&";
                if (firstParam) firstParam = !firstParam;


                // クリップボード置換あり
                if (enableclip && param_list[index].text.Contains("\\c"))
                {
                    clipboardObj = Clipboard.GetDataObject();

                    if(clipboardObj.GetDataPresent(DataFormats.Text))
                    {

                        string tmp;
                        tmp = param_list[index].text.Replace("\\c", (string)clipboardObj.GetData(DataFormats.Text));

                        paramurl += param_list[index].param + "=" + HttpUtility.UrlEncode(tmp, encode);
                    }
                    else
                    {
                        paramurl += param_list[index].ToUriParam(encode);
                    }
                }
                else
                {
                    paramurl += param_list[index].ToUriParam(encode);
                }

            }

            return paramurl.Replace("\n", "").Replace("\r", "");
        }

        static private string ParamUrl(string reText)
        {
            // URLセット
            string paramurl = url;

            // 初回パラメータ用
            bool firstParam = true;

            // パラメータ設定
            // なるべく上から処理するようにしたい
            for (int index = 0; index < param_list.Count; index++)
            {
                if (!param_list[index].ContainText()) continue;

                // 初回のパラーメタ
                paramurl += firstParam ? "?" : "&";
                if (firstParam) firstParam = !firstParam;

                // 置換
                if (param_list[index].text.Contains("\\c"))
                {
                    string tmp = param_list[index].text.Replace("\\c", reText);

                    paramurl += param_list[index].param + "=" + HttpUtility.UrlEncode(tmp, encode);
                }
                else
                {
                    paramurl += param_list[index].ToUriParam(encode);
                }

            }

            return paramurl.Replace("\n", "").Replace("\r", "");
        }

        static public Stream GetStream(out string status)
        {
            status = "";

#if DEBUG
            System.Diagnostics.Trace.WriteLine(paramUrl);
#endif

            // SSL
            ServicePointManager.SecurityProtocol = sptype;
                
            var req = (HttpWebRequest)WebRequest.Create(paramUrl);
            req.Method = "POST";
            req.PreAuthenticate = true;
            // どうもベーシック認証できない
            //req.Credentials = new NetworkCredential(key, pass);
            // これでOK
            req.Headers.Add("Authorization", "Basic " + author_encoded);

            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();

                status = ((int)res.StatusCode).ToString();

                Stream st = res.GetResponseStream();


                return st;
            }
            catch(WebException e)
            {
                //HTTPプロトコルエラーかどうか調べる
                if (e.Status == System.Net.WebExceptionStatus.ProtocolError)
                {
                    //HttpWebResponseを取得
                    System.Net.HttpWebResponse errres =
                        (System.Net.HttpWebResponse)e.Response;
                    //応答ステータスコードを表示する
                    status = ((int)errres.StatusCode).ToString();
                }

            }

            return null;

        }

        static public int StreamPlay(Stream st)
        {
            if (st == null) return -1;
            audio.Play(st, Microsoft.VisualBasic.AudioPlayMode.WaitToComplete);

            audio.Stop();

            return 0;
        }

        // 蛇足メソッド
        static public void AutoGetPlay(out string status, string reText)
        {
            paramUrl = ParamUrl(reText);
            StreamPlay(GetStream(out status));
        }

        static public int StreamPlayTst(string str)
        {
         
            System.Diagnostics.Trace.WriteLine("start");

            audio.Play(str, Microsoft.VisualBasic.AudioPlayMode.WaitToComplete);

            System.Diagnostics.Trace.WriteLine(str);

            audio.Stop();

            System.Diagnostics.Trace.WriteLine("stop");

            return 0;
        }

    }

    #region INI用
    /// <summary>
    /// INIファイル読み書き用
    /// </summary>
    class IniFileHandler
    {
        [DllImport("kernel32.dll")]
        public static extern uint
            GetPrivateProfileString(string lpAppName,
            string lpKeyName, string lpDefault,
            StringBuilder lpReturnedString, uint nSize,
            string lpFileName);

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA")]
        public static extern uint
            GetPrivateProfileStringByByteArray(string lpAppName,
            string lpKeyName, string lpDefault,
            byte[] lpReturnedString, uint nSize,
            string lpFileName);

        [DllImport("kernel32.dll")]
        public static extern uint
            GetPrivateProfileInt(string lpAppName,
            string lpKeyName, int nDefault, string lpFileName);

        [DllImport("kernel32.dll")]
        public static extern uint WritePrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpString,
            string lpFileName);
    }
    /// <summary>
    /// その他Win32NativeMethods用
    /// </summary>
    //    class NativeMethods
    //    {
    //        [DllImport("user32.dll", CharSet = CharSet.Auto)]
    //        public static extern int SendMessage(
    //            IntPtr hWnd,
    //            int msg,
    //            int wParam,
    //            IntPtr lParam);


    //        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
    //        public static extern uint ExtractIconEx(
    //            [MarshalAs(UnmanagedType.LPTStr)]
    //string lpszFile,
    //            int nIconIndex,
    //            [MarshalAs(UnmanagedType.LPArray)]
    //IntPtr[] phiconLarge,
    //            [MarshalAs(UnmanagedType.LPArray)]
    //IntPtr[] phiconSmall,
    //            uint nIcons
    //        );

    //        [DllImport("user32.dll", CharSet = CharSet.Auto)]
    //        public static extern bool DestroyIcon(
    //            IntPtr hIcon);

    //        [DllImport("user32.Dll", CharSet = CharSet.Auto)]
    //        public static extern Int32 RegisterWindowMessage(
    //            [MarshalAs(UnmanagedType.LPTStr)] String lpString);

    //    }
    #endregion
}
