using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace CHomeTask13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Group[] groups = new Group[0];


            string option;
            do
            {
                Console.WriteLine("1.Qrup elave et:");
                Console.WriteLine("2.Qruplara bax:");
                Console.WriteLine("3.Type deyerine gore qruplara bax:");
                Console.WriteLine("4.Bugunden baslamis qruplara bax:");
                Console.WriteLine("5.Son 2 ayda baslamis qruplara bax:");
                Console.WriteLine("6.Bu ayin sonunadek yeni baslayacaq olan qruplara bax:");
                Console.WriteLine("7.Verilmis 2 tarix araliginda baslamis olan qruplara bax:");
                Console.WriteLine("0. Cixis");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("No:");
                        string no = Console.ReadLine();
                        Console.WriteLine("Type:");
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");


                        byte typeByte;
                        string typeStr;
                        do
                        {
                            typeStr = Console.ReadLine();
                            typeByte = Convert.ToByte(typeStr);

                        } while (!Enum.IsDefined(typeof(GroupType), typeByte));

                        GroupType type = (GroupType)typeByte;


                        Console.WriteLine("StartDate:");
                        string startDatestr = Console.ReadLine();
                        DateTime startDate = Convert.ToDateTime(startDatestr);

                        Group group = new Group
                        {
                            No = no,
                            Type = type,
                            StartDate = startDate
                        };

                        Array.Resize(ref groups, groups.Length + 1);
                        groups[groups.Length - 1] = group;
                        break;

                    case "2":
                        foreach (var item in groups)
                        {
                            Console.WriteLine($"No: {item.No} - Type: {item.Type} - StartDate: {item.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;

                    case "3":
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");
                        Console.WriteLine("Type:");
                        typeStr = Console.ReadLine();
                        typeByte = Convert.ToByte(typeStr);
                        type = (GroupType)typeByte;

                        foreach (var item in groups)
                        {
                            if (item.Type == type)
                                Console.WriteLine($"No: {item.No} - Type: {item.Type} - StartDate: {item.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;

                    case "4":
                        DateTime dateTime4 = new DateTime();
                        dateTime4 = DateTime.Now;
                        int count = 0;
                        foreach(var item in groups)
                        {
                            if (item.StartDate<dateTime4)
                            {
                                count++;
                                Console.WriteLine($"{item.Type}-{item.No}-{item.StartDate}");
                            }
                        }
                        if (count == 0)
                        {
                            Console.WriteLine("Qrup movcud deyil.");
                        }
                        break;

                        case "5":
                        DateTime dateTime5 = new DateTime();
                        dateTime5 = DateTime.Now;
                        var nowTime = DateTime.Now.AddMonths(-2);
                        Console.WriteLine(nowTime);
                        break;

                        case "6":
                        int count1 = 0;
                        foreach (var item1 in groups )
                        {
                            if (item1.StartDate.Year >= DateTime.Now.Year && item1.StartDate.Month >= DateTime.Now.Month)
                            {
                                count1++;
                                Console.WriteLine($"No: {item1.No} - Type: {item1.Type} - StartDate: {item1.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                            }
                        }
                        if (count1 == 0)
                        {
                            Console.WriteLine("Bu ay baslayacaq qrup yoxdur.");
                        }
                        break;

                    case "7":
                        Console.WriteLine("1ci ayi daxil edin:");
                        string firstDatestr = Console.ReadLine();
                        DateTime firstDate = Convert.ToDateTime(firstDatestr);

                        Console.WriteLine("2ci ayi daxil edin:");
                        string secondDatestr = Console.ReadLine();
                        DateTime secondDate = Convert.ToDateTime(secondDatestr);

                        foreach (var item2 in groups)
                        {
                            if (item2.StartDate.Year >= DateTime.Now.Year && item2.StartDate.Month >= DateTime.Now.Month)
                            {
                                Console.WriteLine($"No: {item2.No} - Type: {item2.Type} - StartDate: {item2.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                            }
                        }
                        break;

                    case "0":
                        Console.WriteLine("Proqram bitdi");
                        break;

                    default:
                        Console.WriteLine("Seciminiz yanlisdir");
                        break;
                }

            } while (option != "0");
        }
    }
}
