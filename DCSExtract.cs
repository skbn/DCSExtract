using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DCS
{
    class DCSExtract
    {
        [DllImport("DcsExport64.dll")]
        public static extern bool version(ref int mayor, ref int minor);

        [DllImport("DcsExport64.dll")]
        public static extern bool exist_dcs();

        [DllImport("DcsExport64.dll")]
        public static extern bool start_capture();

        [DllImport("DcsExport64.dll")]
        public static extern void stop_capture();

        [DllImport("DcsExport64.dll")]
        public static extern bool exist_ka50();

        [DllImport("DcsExport64.dll")]
        public static extern bool scan_ka50(bool spu9, bool r800, bool r828, bool datalink, bool autopilot);

        [DllImport("DcsExport64.dll")]
        public static extern bool exist_a10c();

        [DllImport("DcsExport64.dll")]
        public static extern bool scan_a10c(bool tacan, bool ils, bool vhf_am, bool vhf_fm);

        public static void Info(ref string inf)
        {
            byte[] data = new byte[128];
            int len = 0;

            info(data, ref len);

            inf = Encoding.ASCII.GetString(data, 0, len);
        }

        //KA50
        public static bool ScanUV26(ref string data)
        {
            byte[] uv = new byte[16];
            int len = 0;

            if (!get_uv26(uv, ref len)) return false;

            data = Encoding.UTF8.GetString(uv, 0, len);

            return true;
        }

        public static bool ScanPVI(ref int upleft, ref string up, ref int upright, ref int downleft, ref string down, ref int downright, ref int mode, ref int buttonprimary, ref int buttonsecondary, ref int buttoneditsecondary, ref bool inu, ref bool reset, ref bool enter)
        {
            byte[] sup = new byte[16];
            int ulen = 0;
            byte[] sdown = new byte[16];
            int dlen = 0;

            if (!get_pvi(ref upleft, sup, ref ulen, ref upright, ref downleft, sdown, ref dlen, ref downright, ref mode, ref buttonprimary, ref buttonsecondary, ref buttoneditsecondary, ref inu, ref reset, ref enter)) return false;

            up = Encoding.UTF8.GetString(sup, 0, ulen);
            down = Encoding.UTF8.GetString(sdown, 0, dlen);

            return true;
        }

        public static bool ScanPui800(ref string left, ref int middle, ref int right)
        {
            byte[] sleft = new byte[16];
            int len = 0;

            if (!get_pui800(sleft, ref len, ref middle, ref right)) return false;

            left = Encoding.UTF8.GetString(sleft, 0, len);

            return true;
        }

        public static bool ScanEkran(ref string memory, ref string queue, ref string failure, ref string line1, ref string line2, ref string line3, ref string line4)
        {
            byte[] mem = new byte[256];
            int memlen = 0;

            byte[] que = new byte[256];
            int quelen = 0;

            byte[] fail = new byte[256];
            int faillen = 0;

            byte[] ln1 = new byte[256];
            int ln1len = 0;

            byte[] ln2 = new byte[256];
            int ln2len = 0;

            byte[] ln3 = new byte[256];
            int ln3len = 0;

            byte[] ln4 = new byte[256];
            int ln4len = 0;

            if (!get_ekran(mem, ref memlen, que, ref quelen, fail, ref faillen, ln1, ref ln1len, ln2, ref ln2len, ln3, ref ln3len, ln4, ref ln4len)) return false;

            memory = Encoding.UTF8.GetString(mem, 0, memlen);
            queue = Encoding.UTF8.GetString(que, 0, quelen);
            failure = Encoding.UTF8.GetString(fail, 0, faillen);
            line1 = Encoding.UTF8.GetString(ln1, 0, ln1len);
            line2 = Encoding.UTF8.GetString(ln2, 0, ln2len);
            line3 = Encoding.UTF8.GetString(ln3, 0, ln3len);
            line4 = Encoding.UTF8.GetString(ln4, 0, ln4len);

            return true;
        }

        public static bool ScanSpu9(ref bool on, ref int channel)
        {
            return get_spu9(ref on, ref channel);
        }

        public static bool ScanR800(ref bool on, ref bool am, ref string frequency, ref bool test, ref bool squelch, ref bool guard, ref bool adf)
        {
            byte[] freq = new byte[256];
            int len = 0;

            if (!get_r800(ref on, ref am, freq, ref len, ref test, ref squelch, ref guard, ref adf)) return false;

            frequency = Encoding.UTF8.GetString(freq, 0, len);

            return true;
        }

        public static bool ScanR828(ref bool on, ref int channel, ref bool tunner)
        {
            return get_r828(ref on, ref channel, ref tunner);
        }

        public static bool ScanDataLink(ref int mode, ref bool sendmem, ref bool clear, ref bool ingress, ref int type, ref int pilot, ref int id, ref bool pvidl, ref bool on, ref bool vhftlk)
        {
            return get_datalink(ref mode, ref sendmem, ref clear, ref ingress, ref type, ref pilot, ref id, ref pvidl, ref on, ref vhftlk);
        }

        public static bool ScanAutopilot(ref int mode, ref int moderoute, ref bool fd, ref int modealtitud, ref bool bank, ref bool blinkbank, ref bool heading, ref bool blinkheading, ref bool altitude, ref bool blinkaltitude, ref bool pitch, ref bool blinkpitch)
        {
            return get_autopilot(ref mode, ref moderoute, ref fd, ref modealtitud, ref bank, ref blinkbank, ref heading, ref blinkheading, ref altitude, ref blinkaltitude, ref pitch, ref blinkpitch);
        }

        //A10C
        public static bool ScanCMSC(ref string chaff, ref string separator, ref string flare, ref string jmr, ref string mws, ref bool unwrapthreats, ref bool unwrapsymbols)
        {
            byte[] ch = new byte[256];
            int chlen = 0;
            byte[] sep = new byte[256];
            int seplen = 0;
            byte[] fl = new byte[256];
            int fllen = 0;
            byte[] jm = new byte[256];
            int jmlen = 0;
            byte[] mw = new byte[256];
            int mwlen = 0;

            if (!get_cmsc(ch, ref chlen, sep, ref seplen, fl, ref fllen, jm, ref jmlen, mw, ref mwlen, ref unwrapthreats, ref unwrapsymbols)) return false;

            chaff = Encoding.UTF8.GetString(ch, 0, chlen);
            separator = Encoding.UTF8.GetString(sep, 0, seplen);
            flare = Encoding.UTF8.GetString(fl, 0, fllen);
            jmr = Encoding.UTF8.GetString(jm, 0, jmlen);
            mws = Encoding.UTF8.GetString(mw, 0, mwlen);

            return true;
        }

        public static bool ScanCMSP(ref string up1, ref string up2, ref string up3, ref string up4, ref string down1, ref string down2, ref string down3, ref string down4)
        {
            byte[] u1 = new byte[256];
            int u1len = 0;
            byte[] u2 = new byte[256];
            int u2len = 0;
            byte[] u3 = new byte[256];
            int u3len = 0;
            byte[] u4 = new byte[256];
            int u4len = 0;
            byte[] d1 = new byte[256];
            int d1len = 0;
            byte[] d2 = new byte[256];
            int d2len = 0;
            byte[] d3 = new byte[256];
            int d3len = 0;
            byte[] d4 = new byte[256];
            int d4len = 0;

            if (!get_cmsp(u1, ref u1len, u2, ref u2len, u3, ref u3len, u4, ref u4len, d1, ref d1len, d2, ref d2len, d3, ref d3len, d4, ref d4len)) return false;

            up1 = Encoding.UTF8.GetString(u1, 0, u1len);
            up2 = Encoding.UTF8.GetString(u2, 0, u2len);
            up3 = Encoding.UTF8.GetString(u3, 0, u3len);
            up4 = Encoding.UTF8.GetString(u4, 0, u4len);
            down1 = Encoding.UTF8.GetString(d1, 0, d1len);
            down2 = Encoding.UTF8.GetString(d2, 0, d2len);
            down3 = Encoding.UTF8.GetString(d3, 0, d3len);
            down4 = Encoding.UTF8.GetString(d4, 0, d4len);

            return true;
        }

        public static bool ScanUHF(ref int channel, ref int functiondial, ref int modefrequency, ref string frequency)
        {
            byte[] freq = new byte[256];
            int freqlen = 0;

            if (!get_uhf(ref channel, ref functiondial, ref modefrequency, freq, ref freqlen)) return false;

            frequency = Encoding.UTF8.GetString(freq, 0, freqlen);

            return true;
        }

        public static bool ScanTacan(ref int modedial, ref string frequency)
        {
            byte[] freq = new byte[256];
            int freqlen = 0;

            if (!get_tacan(ref modedial, freq, ref freqlen)) return false;

            frequency = Encoding.UTF8.GetString(freq, 0, freqlen);

            return true;
        }

        public static bool ScanILS(ref bool on, ref string frequency)
        {
            byte[] freq = new byte[256];
            int freqlen = 0;

            if (!get_ils(ref on, freq, ref freqlen)) return false;

            frequency = Encoding.UTF8.GetString(freq, 0, freqlen);

            return true;
        }

        public static bool ScanVHF_AM(ref bool on, ref int channel, ref int modefrequency, ref int selectfrequency, ref string frequency)
        {
            byte[] freq = new byte[256];
            int freqlen = 0;

            if (!get_vhf_am(ref on, ref channel, ref modefrequency, ref selectfrequency, freq, ref freqlen)) return false;

            frequency = Encoding.UTF8.GetString(freq, 0, freqlen);

            return true;
        }

        public static bool ScanVHF_FM(ref bool on, ref int channel, ref int modefrequency, ref int selectfrequency, ref string frequency)
        {
            byte[] freq = new byte[256];
            int freqlen = 0;

            if (!get_vhf_fm(ref on, ref channel, ref modefrequency, ref selectfrequency, freq, ref freqlen)) return false;

            frequency = Encoding.UTF8.GetString(freq, 0, freqlen);

            return true;
        }

        [DllImport("DcsExport64.dll")]
        private static extern void info([Out] byte[] info, ref int length);

        //KA50
        [DllImport("DcsExport64.dll")]
        private static extern bool get_uv26([Out] byte[] data, ref int length);

        [DllImport("DcsExport64.dll")]
        private static extern bool get_pvi(ref int upleft, [Out] byte[] up, ref int up_length, ref int upright, ref int downleft, [Out] byte[] down, ref int down_length, ref int downright, ref int mode, ref int buttonprimary, ref int buttonsecondary, ref int buttoneditsecondary, ref bool inu, ref bool reset, ref bool enter);

        [DllImport("DcsExport64.dll")]
        private static extern bool get_pui800([Out] byte[] left, ref int left_length, ref int middle, ref int right);

        [DllImport("DcsExport64.dll")]
        private static extern bool get_ekran([Out] byte[] memory, ref int memorylength, [Out] byte[] queue, ref int queuelength, [Out] byte[] failure, ref int failurelength, [Out] byte[] line1, ref int line1length, [Out] byte[] line2, ref int line2length, [Out] byte[] line3, ref int line3length, [Out] byte[] line4, ref int line4length);

        [DllImport("DcsExport64.dll")]
        private static extern bool get_spu9(ref bool on, ref int channel);

        [DllImport("DcsExport64.dll")]
        private static extern bool get_r800(ref bool on, ref bool am, [Out] byte[] frequency, ref int frequency_length, ref bool test, ref bool squelch, ref bool guard, ref bool adf);

        [DllImport("DcsExport64.dll")]
        private static extern bool get_r828(ref bool on, ref int channel, ref bool buttontuner);

        [DllImport("DcsExport64.dll")]
        private static extern bool get_datalink(ref int mode, ref bool sendmem, ref bool clear, ref bool ingress, ref int type, ref int pilot, ref int id, ref bool pvidl, ref bool on, ref bool vhftlk);

        [DllImport("DcsExport64.dll")]
        private static extern bool get_autopilot(ref int mode, ref int moderoute, ref bool fd, ref int modealtitud, ref bool bank, ref bool blinkbank, ref bool heading, ref bool blinkheading, ref bool altitude, ref bool blinkaltitude, ref bool pitch, ref bool blinkpitch);

        //A10C
        [DllImport("DcsExport64.dll")]
        private static extern bool get_cmsc([Out] byte[] chaff, ref int chaff_length, [Out] byte[] separator, ref int separator_length, [Out] byte[] flare, ref int flare_length, [Out] byte[] jmr, ref int jmr_length, [Out] byte[] mws, ref int mws_length, ref bool unwrapthreats, ref bool unwrapsymbols);

        [DllImport("DcsExport64.dll")]
        private static extern bool get_cmsp([Out] byte[] up1, ref int up1_length, [Out] byte[] up2, ref int up2_length, [Out] byte[] up3, ref int up3_length, [Out] byte[] up4, ref int up4_length, [Out] byte[] down1, ref int down1_length, [Out] byte[] down2, ref int down2_length, [Out] byte[] down3, ref int down3_length, [Out] byte[] down4, ref int down4_length);

        [DllImport("DcsExport64.dll")]
        private static extern bool get_uhf(ref int channel, ref int functiondial, ref int modefrequency, [Out] byte[] frequency, ref int frequency_length);

        [DllImport("DcsExport64.dll")]
        private static extern bool get_tacan(ref int modedial, [Out] byte[] frequency, ref int frequency_length);

        [DllImport("DcsExport64.dll")]
        private static extern bool get_ils(ref bool on, [Out] byte[] frequency, ref int frequency_length);

        [DllImport("DcsExport64.dll")]
        private static extern bool get_vhf_am(ref bool on, ref int channel, ref int modefrequency, ref int selectfrequency, [Out] byte[] frequency, ref int frequency_length);

        [DllImport("DcsExport64.dll")]
        private static extern bool get_vhf_fm(ref bool on, ref int channel, ref int modefrequency, ref int selectfrequency, [Out] byte[] frequency, ref int frequency_length);


        //Keys
        public enum KeyCode : int
        {
            None = 0x00,
            LButton = 0x01,
            RButton = 0x02,
            Cancel = 0x03,
            MButton = 0x04,
            XButton1 = 0x05,
            XButton2 = 0x06,
            Back = 0x08,
            Tab = 0x09,
            Clear = 0x0C,
            Return = 0x0D,
            Shift = 0x10,
            Control = 0x11,
            Menu = 0x12,
            Pause = 0x13,
            Capital = 0x14,
            Kana = 0x15,
            Hangeul = 0x15,
            Hangul = 0x15,
            Junja = 0x17,
            Final = 0x18,
            Hanja = 0x19,
            Kanji = 0x19,
            Escape = 0x1B,
            Convert = 0x1C,
            NonConvert = 0x1D,
            Accept = 0x1E,
            ModeChange = 0x1F,
            Space = 0x20,
            Prior = 0x21,
            Next = 0x22,
            End = 0x23,
            Home = 0x24,
            Left = 0x25,
            Up = 0x26,
            Right = 0x27,
            Down = 0x28,
            Select = 0x29,
            Print = 0x2A,
            Execute = 0x2B,
            Snapshot = 0x2C,
            Insert = 0x2D,
            Delete = 0x2E,
            Help = 0x2F,
            VK_0 = 0x30,
            VK_1 = 0x31,
            VK_2 = 0x32,
            VK_3 = 0x33,
            VK_4 = 0x34,
            VK_5 = 0x35,
            VK_6 = 0x36,
            VK_7 = 0x37,
            VK_8 = 0x38,
            VK_9 = 0x39,
            VK_A = 0x41,
            VK_B = 0x42,
            VK_C = 0x43,
            VK_D = 0x44,
            VK_E = 0x45,
            VK_F = 0x46,
            VK_G = 0x47,
            VK_H = 0x48,
            VK_I = 0x49,
            VK_J = 0x4A,
            VK_K = 0x4B,
            VK_L = 0x4C,
            VK_M = 0x4D,
            VK_N = 0x4E,
            VK_O = 0x4F,
            VK_P = 0x50,
            VK_Q = 0x51,
            VK_R = 0x52,
            VK_S = 0x53,
            VK_T = 0x54,
            VK_U = 0x55,
            VK_V = 0x56,
            VK_W = 0x57,
            VK_X = 0x58,
            VK_Y = 0x59,
            VK_Z = 0x5A,
            LWin = 0x5B,
            RWin = 0x5C,
            Apps = 0x5D,
            Sleep = 0x5F,
            NUMPAD_0 = 0x60,
            NUMPAD_1 = 0x61,
            NUMPAD_2 = 0x62,
            NUMPAD_3 = 0x63,
            NUMPAD_4 = 0x64,
            NUMPAD_5 = 0x65,
            NUMPAD_6 = 0x66,
            NUMPAD_7 = 0x67,
            NUMPAD_8 = 0x68,
            NUMPAD_9 = 0x69,
            Multiply = 0x6A,
            Add = 0x6B,
            Separator = 0x6C,
            Subtract = 0x6D,
            Decimal = 0x6E,
            Divide = 0x6F,
            F1 = 0x70,
            F2 = 0x71,
            F3 = 0x72,
            F4 = 0x73,
            F5 = 0x74,
            F6 = 0x75,
            F7 = 0x76,
            F8 = 0x77,
            F9 = 0x78,
            F10 = 0x79,
            F11 = 0x7A,
            F12 = 0x7B,
            F13 = 0x7C,
            F14 = 0x7D,
            F15 = 0x7E,
            F16 = 0x7F,
            F17 = 0x80,
            F18 = 0x81,
            F19 = 0x82,
            F20 = 0x83,
            F21 = 0x84,
            F22 = 0x85,
            F23 = 0x86,
            F24 = 0x87,
            Numlock = 0x90,
            Scroll = 0x91,
            LShift = 0xA0,
            RShift = 0xA1,
            LControl = 0xA2,
            RControl = 0xA3,
            LMenu = 0xA4,
            RMenu = 0xA5,
            BROWSER_BACK = 0xA6,
            BROWSER_FORWARD = 0xA7,
            BROWSER_REFRESH = 0xA8,
            BROWSER_STOP = 0xA9,
            BROWSER_SEARCH = 0xAA,
            BROWSER_FAVORITES = 0xAB,
            BROWSER_HOME = 0xAC,
            VOLUME_MUTE = 0xAD,
            VOLUME_DOWN = 0xAE,
            VOLUME_UP = 0xAF,
            MEDIA_NEXT_TRACK = 0xB0,
            MEDIA_PREV_TRACK = 0xB1,
            MEDIA_STOP = 0xB2,
            MEDIA_PLAY_PAUSE = 0xB3,
            LAUNCH_MAIL = 0xB4,
            LAUNCH_MEDIA_SELECT = 0xB5,
            LAUNCH_APP1 = 0xB6,
            LAUNCH_APP2 = 0xB7,
            OEM_1 = 0xBA,
            OEM_PLUS = 0xBB,
            OEM_COMMA = 0xBC,
            OEM_MINUS = 0xBD,
            OEM_PERIOD = 0xBE,
            OEM_2 = 0xBF,
            OEM_3 = 0xC0,
            OEM_4 = 0xDB,
            OEM_5 = 0xDC,
            OEM_6 = 0xDD,
            OEM_7 = 0xDE,
            OEM_8 = 0xDF,
            OEM_102 = 0xE2,
            PROCESS_KEY = 0xE5,
            PACKET = 0xE7,
            ATTN = 0xF6,
            CRSEL = 0xF7,
            EXSEL = 0xF8,
            EREOF = 0xF9,
            PLAY = 0xFA,
            ZOOM = 0xFB,
            NONAME = 0xFC,
            PA1 = 0xFD,
            OEM_CLEAR = 0xFE
        }

        [DllImport("DcsExport64.dll")]
        private static extern void getscancode(int key, ref int value);

        public static int GetScanCode(int key)
        {
            int scan = 0;
            getscancode(key, ref scan);
            return scan;
        }

        [DllImport("DcsExport64.dll")]
        private static extern void getkeyname(int key, [Out] byte[] name, ref int name_length);

        public static string GetKeyName(int key)
        {
            byte[] tmp = new byte[256];
            int tmplen = 0;

            getkeyname(key, tmp, ref tmplen);

            return Encoding.ASCII.GetString(tmp, 0, tmplen);
        }

		//Send press and release
        [DllImport("DcsExport64.dll")]
        public static extern void presskey1(KeyCode key1);

        [DllImport("DcsExport64.dll")]
        public static extern void presskey2(KeyCode key1, KeyCode key2);

        [DllImport("DcsExport64.dll")]
        public static extern void presskey3(KeyCode key1, KeyCode key2, KeyCode key3);

        [DllImport("DcsExport64.dll")]
        public static extern void presskey4(KeyCode key1, KeyCode key2, KeyCode key3, KeyCode key4);

		//Send press
        [DllImport("DcsExport64.dll")]
        public static extern void key_down1(KeyCode key1);

        [DllImport("DcsExport64.dll")]
        public static extern void key_down2(KeyCode key1, KeyCode key2);

        [DllImport("DcsExport64.dll")]
        public static extern void key_down3(KeyCode key1, KeyCode key2, KeyCode key3);

        [DllImport("DcsExport64.dll")]
        public static extern void key_down4(KeyCode key1, KeyCode key2, KeyCode key3, KeyCode key4);

		//Send release
        [DllImport("DcsExport64.dll")]
        public static extern void key_up1(KeyCode key1);

        [DllImport("DcsExport64.dll")]
        public static extern void key_up2(KeyCode key1, KeyCode key2);

        [DllImport("DcsExport64.dll")]
        public static extern void key_up3(KeyCode key1, KeyCode key2, KeyCode key3);

        [DllImport("DcsExport64.dll")]
        public static extern void key_up4(KeyCode key1, KeyCode key2, KeyCode key3, KeyCode key4);
    }
}
