using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoc_json
{
    class Vu_khi
    {
        
        // Du lieu
        public string name = "tên vũ khí";
        public string Noisanxuat { get; set; }
        int dosatthuong = 0;
        // thuộc tính
        public int Satthuong
        {
            // =
            set
            {
                dosatthuong = value;
            }
            //truy cập,lấy về
            get
            {
                return dosatthuong;
            }
        }
        public void Thietlapsatthuong(int dosatthuong)
        {
            this.dosatthuong = dosatthuong;
        }
        public void Tancong()
        {
            Console.Write(name + ": ");
            for (int i = 0; i < dosatthuong; i++)
            {
                Console.Write(" * ");
            }
            Console.WriteLine();
            //
        }
    }
}
