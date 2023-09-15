using OfficeOpenXml;

namespace ConsoleParser
{

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ParseXlsx(AppDomain.CurrentDomain.BaseDirectory + "/maga.xlsx");

            Console.ReadKey();
        }
        public static void ParseXlsx(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                var columnCount = worksheet.Dimension.Columns;

                for (int row = 1; row <= rowCount; row++)
                {
                    for (int col = 1; col <= columnCount; col++)
                    {

                        var cellValue = worksheet.Cells[row, col].Value;
                        if (cellValue is null) continue;
                        Console.WriteLine($"Row number: {row} column number: {col} Cell value: {(cellValue == null ? "null": cellValue)} ");

                    }
                }
                Console.WriteLine("Thats all");

                var value = worksheet.Cells[1, 3].Value.ToString();
                var str = value.Trim();
                Console.WriteLine(str);

            }

        }
    }
}