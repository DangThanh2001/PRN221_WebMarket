using DataAccess.IRepositotry;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace Service
{
    public class ProductService
    {

        private IProductRepository productRepository;
        private AccountService _accountService;

        public ProductService(IProductRepository productRepository, AccountService accountService)
        {
            this.productRepository = productRepository;
            _accountService = accountService;
        }

        public List<Product> GetAllProduct()
        {
            return productRepository.GetAllProduct();
        }
        public List<Product> GetAllProducByUserId()
        {
            try
            {
                var userID = _accountService.GetAccountId();
                return productRepository.GetProductWithUserId(int.Parse(userID));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Product GetProductWithId(int id)
        {
            return productRepository.GetProductWithId(id);
        }

        public void AddProduct(Product product)
        {
            productRepository.AddProduct(product);
        }

        public void UpdateCategory(Product product)
        {
            productRepository.UpdateProduct(product);
        }

        public void DeleteCategory(int id)
        {
            productRepository.DeleteProduct(id);
        }

        public List<Product> listAllProduct()
        {
            return productRepository.GetAllProduct();
        }
        public void ExportToExcel(string filePath, List<Product> productList)
        {
            // Tạo file Excel mới
            using (var spreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                // Tạo một bảng tính mới
                var workbookPart = spreadsheetDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                // Thêm một trang tính mới vào bảng tính
                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                // Thêm một sheet mới vào workbook
                var sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
                sheets.AppendChild(new Sheet
                {
                    Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Product List"
                });

                // Lấy SheetData từ WorksheetPart
                var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                // Thêm hàng tiêu đề vào SheetData
                var headerRow = new Row();
                headerRow.Append(new Cell(new InlineString(new Text("Product Name"))));
                headerRow.Append(new Cell(new InlineString(new Text("Descrition"))));
                headerRow.Append(new Cell(new InlineString(new Text("Price"))));
                headerRow.Append(new Cell(new InlineString(new Text("Quantity"))));
                headerRow.Append(new Cell(new InlineString(new Text("Actice"))));
                sheetData.AppendChild(headerRow);

                // Thêm dữ liệu sản phẩm vào SheetData
                foreach (var product in productList)
                {
                    var productRow = new Row();
                    productRow.Append(new Cell(new InlineString(new Text(product.ProductName))));
                    productRow.Append(new Cell(new InlineString(new Text(product.ProductDescription))));
                    productRow.Append(new Cell(new InlineString(new Text(product.Price.ToString()))));
                    productRow.Append(new Cell(new InlineString(new Text(product.Quantity.ToString()))));
                    productRow.Append(new Cell(new InlineString(new Text(product.IsActive? "True": "False"))));
                    sheetData.AppendChild(productRow);
                }
            }
        }
        public List<Product> ImportProductsFromExcel(string filePath)
        {
            var products = new List<Product>();

            FileInfo fileInfo = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                int rowCount = worksheet.Dimension.Rows;

                for (int i = 2; i <= rowCount; i++)
                {
                    var product = new Product
                    {
                        ProductName = worksheet.Cells[i, 1].Value.ToString(),
                        ProductDescription = worksheet.Cells[i, 2].Value.ToString(),
                        Price = int.Parse(worksheet.Cells[i, 3].Value.ToString()),
                        Quantity = int.Parse(worksheet.Cells[i, 4].Value.ToString()),
                        ProductCategory = worksheet.Cells[i, 5].Value.ToString()
                    };

                    products.Add(product);
                }
            }
            return products;
        }
    }
}
