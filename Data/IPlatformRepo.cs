using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepo
    {
        bool SaveChanges();

        IEnumerable<Platform> getAllPlatforms(); // What is enumerable?
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform platform);
    }
}