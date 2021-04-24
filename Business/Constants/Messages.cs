namespace Business.Constants
{
    public static class Messages
    {
        #region Success Messages
        public static string SuccessAdded = "Ekleme Basarili.";
        public static string SuccessUpdated = "Guncelleme Basarili.";
        public static string SuccessDeleted = "Silme basarili.";
        public static string SuccessListed = "Listeleme Basarili.";
        #endregion

        #region Error Messages
        public static string NameInvalidError = "Girilen ad gecersiz.";
        public static string MaintenanceTimeError = "Sistem bakimdadir.";
        public static string ErrorAdded = "Ekleme başarısız.";
        public static string ErrorUpdated = "Guncelleme başarısız.";
        public static string ErrorDeleted = "Silme başarısız.";
        public static string ErrorListed = "Listeleme başarısız.";
        internal static string NotFound = "Kayıt bulunamadı.";
        #endregion

        #region Authorization Messages
        public static string AuthorizationDenied = "Yetkilendirme hatasi.";
        public static string UserNotFound = "Kullanici bulunamadi.";
        public static string PasswordError = "Parola hatasi.";
        public static string SuccessLogin = "Giris basarili.";
        public static string UserAlreadyExists = "Bu kullanici zaten kayitli.";
        public static string AccessTokenCreated = "Access token olusturuldu.";
        public static string UserRegistered = "Kullanici kaydedildi";
        public static string ClaimsNotFound = "Aranan nitelikte kayit bulunamadi.";
        public static string ClaimAdded = "Yetki verildi.";
        #endregion
    }
}
