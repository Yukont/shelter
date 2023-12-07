﻿using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace BLL.ImgWork
{
    public class ImgService
    {
        public async Task<string> ProcessImage(IFormFile imageFile, string uploadFolder)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Генерируйте уникальное имя файла
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;

                // Полный путь к сохраняемому файлу
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                // Сохраните файл на сервере
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // Обрежьте изображение до нужного размера
                using (var image = Image.Load(filePath))
                {
                    int desiredWidth = 900; // Желаемая ширина обрезанного изображения
                    int desiredHeight = 900; // Желаемая высота обрезанного изображения

                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new Size(desiredWidth, desiredHeight),
                        Mode = ResizeMode.Crop
                    }));

                    // Сохраните обрезанное изображение обратно на диск
                    image.Save(filePath);
                }

                // Верните путь к изображению
                return "/uploads/" + uniqueFileName;
            }

            return null; // В случае, если файл изображения не был выбран
        }
        public void DeleteImg(string? filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
