using System;
using System.Threading.Tasks;
using PCLStorage;

namespace matthewjoughin.bankingapp.xamarin
{
    public static class Public
    {
		public async static Task<bool> IsFileExistAsync(this string fileName, IFolder rootFolder = null)
		{
			// get hold of the file system  
			IFolder folder = rootFolder ?? FileSystem.Current.LocalStorage;
			ExistenceCheckResult folderexist = await folder.CheckExistsAsync(fileName);
			// already run at least once, don't overwrite what's there  
			if (folderexist == ExistenceCheckResult.FileExists)
			{
				return true;

			}
			return false;
		}

		public async static Task<string> ReadAllTextAsync(this string fileName, IFolder rootFolder = null)
		{
			string content = "";
			IFolder folder = rootFolder ?? FileSystem.Current.LocalStorage;
			bool exist = await fileName.IsFileExistAsync(folder);
			if (exist == true)
			{
				IFile file = await folder.GetFileAsync(fileName);
				content = await file.ReadAllTextAsync();
			}
			return content;
		}
	}
}