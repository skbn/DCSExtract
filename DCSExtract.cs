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
        public static extern bool exist_a10c();

        public static void Info(ref string inf)
        {
            byte[] data = new byte[128];
            int len = 0;

            info(data, ref len);

            inf = Encoding.ASCII.GetString(data, 0, len);
        }

        public static bool ScanUV26(ref string data)
        {
            byte[] uv = new byte[16];
            int len = 0;

            bool ret = scan_uv26(uv, ref len);

            data = Encoding.ASCII.GetString(uv, 0, len);

            return ret;
        }

        public static bool ScanPVI(ref int upleft, ref string up, ref int upright, ref int downleft, ref string down, ref int downright)
        {
            byte[] sup = new byte[16];
            int ulen = 0;
            byte[] sdown = new byte[16];
            int dlen = 0;

            bool ret = scan_pvi(ref upleft, sup, ref ulen, ref upright, ref downleft, sdown, ref dlen, ref downright);

            up = Encoding.ASCII.GetString(sup, 0, ulen);
            down = Encoding.ASCII.GetString(sdown, 0, dlen);

            return ret;
        }

        public static bool ScanPui800(ref string left, ref int middle, ref int right)
        {
            byte[] sleft = new byte[16];
            int len = 0;

            bool ret = scan_pui800(sleft, ref len, ref middle, ref right);

            left = Encoding.UTF8.GetString(sleft, 0, len);

            return ret;
        }

        public static bool ScanEkran(ref string memory, ref string queue, ref string failure, ref string message)
        {
            byte[] mem = new byte[256];
            int memlen = 0;

            byte[] que = new byte[256];
            int quelen = 0;

            byte[] fail = new byte[256];
            int faillen = 0;

            byte[] msg = new byte[256];
            int msglen = 0;

            bool ret = scan_ekran(mem, ref memlen, que, ref quelen, fail, ref faillen, msg, ref msglen);

            memory = Encoding.ASCII.GetString(mem, 0, memlen);
            queue = Encoding.ASCII.GetString(que, 0, quelen);
            failure = Encoding.ASCII.GetString(fail, 0, faillen);
            message = Encoding.ASCII.GetString(msg, 0, msglen);

            return ret;
        }

        [DllImport("DcsExport64.dll")]
        private static extern bool scan_uv26([Out] byte[] data, ref int length);

        [DllImport("DcsExport64.dll")]
        private static extern bool scan_pvi(ref int upleft, [Out] byte[] up, ref int up_length, ref int upright, ref int downleft, [Out] byte[] down, ref int down_length, ref int downright);

        [DllImport("DcsExport64.dll")]
        private static extern bool scan_pui800([Out] byte[] left, ref int left_length, ref int middle, ref int right);

        [DllImport("DcsExport64.dll")]
        private static extern bool scan_ekran([Out] byte[] memory, ref int memorylength, [Out] byte[] queue, ref int queuelength, [Out] byte[] failure, ref int failurelength, [Out] byte[] message, ref int messagelength);

        [DllImport("DcsExport64.dll")]
        private static extern void info([Out] byte[] info, ref int length);
    }
}
