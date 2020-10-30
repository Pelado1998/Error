// using System.Collections.Generic;

// namespace Bankbot
// {
//     /// <summary>
//     /// Esta clase cumple con el patrón Expert del principio GRASP ya que es la que contiene toda la información
//     /// sobre Currency, pero tambien con el patrón SRP por tener una unica razón de cambio.
//     /// </summary>
//     public class GoogleDriveSender
//     {
//         // Get all users
//         // Get user accounts
//         // Upload users
//         // Upload account

//         public static List<User> GetAllUsers()
//         {
//             var userList = new List<User>();
//             var path = @".\..\GoogleDrive\files\Users.txt";
//             var file = GoogleDrive.FindFile.GetFile("Users.txt");
//             GoogleDrive.Download.DownloadFile(file, path);
//             var lines = GoogleDrive.FileModification.ReadAllLines(path);

//             while (true)
//             {
//                 if (lines.Length > 0)
//                 {
//                     break;
//                 }
//             }

//             foreach (var line in lines)
//             {
//                 var splitUser = line.Split(",");
//                 var user = new User(splitUser);
//                 userList.Add(user);
//             }

//             return userList;
//         }

//         public static List<Account> GetUserAccounts(User user)
//         {
// 
//         }
//     }
// }