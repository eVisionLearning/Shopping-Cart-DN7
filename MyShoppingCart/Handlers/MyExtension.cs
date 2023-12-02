
namespace MyShoppingCart.Handlers
{
    public static class MyExtension
    {
        public static string SaveUploadedFile(this IFormFile upload, params string[] path)
        {
            if (upload == null || upload.Length == 0) return null;

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(upload.FileName);
            string applicationRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            string directoryPath = string.Empty;
            foreach (var folder in path)
            {
                directoryPath = Path.Combine(directoryPath, folder);
            }

            var aPath = Path.Combine(applicationRootPath, directoryPath);
            Directory.CreateDirectory(aPath);
            var filePath = Path.Combine(aPath, fileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            upload.CopyTo(fileStream);

            var url = "/" + Path.Combine(directoryPath, fileName).Replace("\\", "/");
            return url;
        }
    }
}
