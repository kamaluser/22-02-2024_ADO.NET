
using _22_02_2024_ADO.NET;

//List <Brand> brands = new List<Brand>();
BrandService brandService = new BrandService();
string opt;
do
{
    Console.WriteLine("\n\tMENU\n");
    Console.WriteLine("1. Create");
    Console.WriteLine("2. Delete");
    Console.WriteLine("3. Get By Id");
    Console.WriteLine("4. Get All");
    Console.WriteLine("5. Update");
    Console.WriteLine("0. Exit");



    Console.WriteLine("Select Operation: ");
    opt = Console.ReadLine();


    switch (opt)
    {
        case "1":
            
            string name;
            do
            {
                Console.WriteLine("Name:");
                name = Console.ReadLine();
            } while (String.IsNullOrWhiteSpace(name));


            string yearStr;
            int year;
            do
            {
                Console.WriteLine("Year: ");
                yearStr = Console.ReadLine();
            } while (!int.TryParse(yearStr, out year) || year < 0);
            brandService.InsertBrand(name, year);

            break;
        case "2":
            string idStr;
            int id;
            do
            {
                Console.WriteLine("Id: ");
                idStr = Console.ReadLine();
            } while (!int.TryParse(idStr, out id) || id<0);
            brandService.DeleteBrand(id);
            break;
        case "3":

            string idStr1;
            int id1;
            do
            {
                Console.WriteLine("Id: ");
                idStr1 = Console.ReadLine();
            } while (!int.TryParse(idStr1, out id1) || id1 < 0);
            Console.WriteLine(brandService.GetBrandById(id1));
            break;
        case "4":
            Console.WriteLine("All Brands:\n------------");
            foreach (var item in brandService.GetAllBrands())
            {
                Console.WriteLine(item);
            }
            break;
        case "5":



            string idStr2;
            int id2;
            do
            {
                Console.WriteLine("Select Id To Update: ");
                idStr2 = Console.ReadLine();
            } while (!int.TryParse(idStr2, out id2) || id2 < 0);

            string newName;
            do
            {
                Console.WriteLine("Name:");
                newName = Console.ReadLine();
            } while (String.IsNullOrWhiteSpace(newName));


            string newYearStr;
            int newYear;
            do
            {
                Console.WriteLine("Year: ");
                newYearStr = Console.ReadLine();
            } while (!int.TryParse(newYearStr, out newYear) || newYear < 0);
            brandService.UpdateBrand(id2, newName, newYear);
            break;
        case "0":
            Console.WriteLine("Finished");
            break;
        default:
            Console.WriteLine("Invalid Choice!");
            break;
    }


} while (opt != "0");