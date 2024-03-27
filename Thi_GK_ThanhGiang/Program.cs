using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thi_GK_ThanhGiang
{
    class Program
    {
        static void Main(string[] args)
        {
            List<KhuPho> listKhuPho = new List<KhuPho>()
            {
                new KhuPho(1,"Khu Pho 1"),
                new KhuPho(2,"Khu Pho 2")
            };
            List<HoGiaDinh> listHoGiaDinh = new List<HoGiaDinh>()
            {
                new HoGiaDinh(1,3,1,0,"646 Ton Dan",1),
                new HoGiaDinh(2,8,4,2,"49 Tran Cao Van",1),
                new HoGiaDinh(3,4,1,1,"70 Cao Thang",2)
            };
            List<Nguoi> listNguoi = new List<Nguoi>()
            {
                new Nguoi("Giang", 21, "Sinh viên", "1234",1),
                new Nguoi("Hung", 50, "Giao vien", "1235",1),
                new Nguoi("Thu", 47, "Noi tro", "1236",1),
                new Nguoi("Vu", 47, "Cong nhan", "1237",2),
                new Nguoi("Ngan", 40, "Cong nhan", "1238",2),
                new Nguoi("Dat", 18, "Hoc sinh", "1239",2),
                new Nguoi("Trinh", 15, "Hoc sinh", "1210",2),
                new Nguoi("Nga", 21, "Hoc sinh", "1211",2),
                new Nguoi("Duc", 38, "Kien truc su", "1212",3),
                new Nguoi("Truc", 30, "Noi tro", "1213",3),
                new Nguoi("Nhu", 10, "Hoc sinh", "1214",3),
                new Nguoi("Nhung", 5, "Hoc sinh", "1215",3)
            };

            var list = listKhuPho.Join(listHoGiaDinh, k => k.khuPho, h => h.khuPho,
                (k, h) => new { k, h })
                .Join(listNguoi, l => l.h.hoGiaDinh, n => n.hoGiaDinh,
                (l, n) => new { l, n });
            Console.WriteLine("Thong tin thanh vien trong khu pho: ");
            foreach(var item in list)
            {
                Console.WriteLine($"Khu pho: {item.l.k.khuPho}, Ho gia dinh: {item.l.h.hoGiaDinh}, so thanh vien: {item.l.h.soThanhVien}, thanh vien: {item.n.hoTen}, tuoi: {item.n.tuoi}, nghe nghiep: {item.n.ngheNghiep}");
            }

            Console.Write("Nhap vao n: ");
            int so = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i<so; i++)
            {
                Console.WriteLine($"Ho: {listHoGiaDinh[i].hoGiaDinh}, so thanh vien: {listHoGiaDinh[i].soThanhVien} , so con trai: {listHoGiaDinh[i].soConTrai} , so con gai: {listHoGiaDinh[i].soConGai} , so nha: {listHoGiaDinh[i].soNha}");
            }

            Console.WriteLine("\nHo gia dinh co so con trai >= 2");
            var listgdcontrai = listHoGiaDinh.Where(li => li.soConTrai >= 2);
            foreach(var item in listgdcontrai)
            {
                Console.WriteLine($"Ho:{item.hoGiaDinh} so thanh vien: {item.soThanhVien}, so con trai: {item.soConTrai}, so con gai: {item.soConGai}, so nha: {item.soNha}");
            }

            var listHoGiaDinhinKhuPho = listHoGiaDinh.Join(listKhuPho, h => h.khuPho, k => k.khuPho, (h, k) => new { h, k });

            Console.WriteLine("\nTong so thanh vien trong khu pho: ");
            var tongthanhvien = listHoGiaDinhinKhuPho.GroupBy(l => l.k.khuPho).Select(group => new
            {
                KhuPho = group.Key,
                Total = group.Sum(gr => gr.h.soThanhVien)
            }) ;
            foreach (var item in tongthanhvien)
            {
                Console.WriteLine($"Khu phu:{item.KhuPho} so thanh vien: {item.Total}");
            }
            var listds = listHoGiaDinh.Where((h) => (h.soConTrai + h.soConGai)> 5 && (h.soConTrai + h.soConGai) < 10);           
            Console.WriteLine("\nHo gia dinh co so con tu 5 de 10");
            foreach (var item in listds)
            {
                Console.WriteLine($"Ho: {item.hoGiaDinh}, so thanh vien: {item.soThanhVien} , so con trai: {item.soConTrai} , so con gai: {item.soConGai} , so nha: {item.soNha}");
            }
            var listHung = list.Where(l => l.n.hoTen.ToLower().Equals("hung"));
            Console.WriteLine("\nHo gia dinh co nguoi ten Hung");
            foreach(var item in listHung)
            {
                Console.WriteLine($"Ho gia dinh: {item.l.h.hoGiaDinh}, thanh vien: {item.n.hoTen}");
            }
            var tongnamnu = listHoGiaDinhinKhuPho.GroupBy(l => l.k.khuPho).Select(group => new
            {
                KhuPho = group.Key,
                TotalNam = group.Sum(gr => gr.h.soConTrai),
                TotalNu = group.Sum(gr => gr.h.soConGai)
            });
            Console.WriteLine("\nThong ke so con nam, nu trong khu pho");
            foreach (var item in tongnamnu)
            {
                Console.WriteLine($"Khu phu:{item.KhuPho} so nam: {item.TotalNam}, so nu: {item.TotalNu}");
            }
            

            Console.ReadLine();
        }
    }
}
