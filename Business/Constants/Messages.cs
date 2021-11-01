using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MovieAdded = "Film eklendi.";
        public static string ExistingMovie = "Eklemek istediğiniz film mevcut.";
        public static string NotExistMovie = "Film bulunamadı";
        public static string UpdatedMovie = "Film bilgileri güncellendi";
        public static string DeletedMovie = "Film silindi.";

        public static string NotExistPerformer = "Oyuncu bulunamadı";
        public static string PerformerAdded = "Oyuncu eklendi.";
        public static string ExistingPerformer = "Eklemek istediğiniz oyuncu mevcut.";
        public static string UpdatedPerformer = "Oyuncu bilgileri güncellendi";
        public static string DeletedPerformer = "Oyuncu silindi.";

        public static string NotExistDirector = "Yönetmen bulunamadı";
        public static string DirectorAdded = "Yönetmen eklendi.";
        public static string ExistingDirector = "Eklemek istediğiniz yönetmen mevcut.";
        public static string UpdatedDirector = "Yönetmen bilgileri güncellendi";
        public static string DeletedDirector = "Yönetmen silindi.";

        public static string ExistingCustomer = "Eklemek istediğiniz kullanıcı mevcut.";
        public static string CustomerAdded = "Kullanıcı eklendi.";
        public static string NotExistCustomer = "Kullanıcı bulunamadı.";
        public static string DeletedCustomer = "Kullanıcı silindi.";

        public static string AuthorizationDenied = "Erişim yetkiniz yok!";

        public static string UserRegistered = "Kayıt oluşturuldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola Hatalı!";
        public static string SuccessfulLogin = "Hoşgeldiniz!";
        public static string UserAlreadyExists = "Kullanıcı mevcut!";
        public static string AccessTokenCreated = "Token Hazır!";

        public static string AddedOrder = "Siparişiniz alındı.";

        public static string NotExistOrder = "Gösterilecek sipariş henüz yok.";


    }
}
