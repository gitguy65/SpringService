public static class ImageUpload 
{
  public static async Task<string> UploadAsync(IFormFile file)
  {
    List<string> validExtensions = new List<string>() {".jpg",".png", ".jpeg"};
    string extension = Path.GetExtension(file.FileName);

    if(!validExtensions.Contains(extension))
      return $"extension is not valid ({string.Join(',',validExtensions)})"; 
    
    long size = file.Length;
    if(size > 5 * 2048)
      return "Maximum size is 5mb";

    string fileName = Guid.NewGuid().ToString() + extension;
    string path = Path.Combine(Directory.GetCurrentDirectory(),"Uploads");
    using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create); 
    await file.CopyToAsync(stream);
    return fileName;
  }
}