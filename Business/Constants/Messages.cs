using Core.Entities.Concrete;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        #region Veri İşlemleri
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductDeleted = "Ürün Silindi.";
        public static string ProductUpdated = "Ürün Güncellendi.";

        public static string CategoryAdded = "Kategori Eklendi.";
        public static string CategoryDeleted = "Kategori Silindi.";
        public static string CategoryUpdated = "Kategori Güncellendi.";

        public static string OrderAdded = "Sipariş Eklendi.";
        public static string OrderDeleted = "Sipariş Silindi.";
        public static string OrderUpdated = "Sipariş Güncellendi.";
        //Get Part
        public static string ProductListed = "Ürünler Listelendi.";
        public static string ProductListedByCategoryId = "Ürünler Kategoriye Göre Listelendi.";
        public static string ProductGetById = "Ürün Id'sine Göre Ürün Getirilmiştir.";
        public static string ProductListedByUnitPrice = "Birim Fiyatına Göre Listelenmiştir.";
        public static string ProductDetailListed = "Ürünler Detaylarıyla Listelenmiştir.";
        public static string ProductNotListed= "Ürünler Listelenememiştir.";


        internal static string CategoryGetById = "Kategori Id'sine Göre Getirilmiştir.";
        internal static string CategoryListed = "Kategoriler Getirilmiştir.";
        #endregion

        #region Hata Mesajları
        public static string ProductNameInvalid = "Ürün Adı Uygun Değil.";
        public static string ProductNameAlreadyExist= "Ürün Adı Zaten Mevcut.";
        public static string MaxLimitOfProductInCategory = "Bir Kategoride ki Ürün Limiti Aşıldı.";
        public static string MaxCategoryLimit= "Kategori Sayısı Sınırı Geçti.";
        public static string? AuthorizationDenied = "Yetkisiz Giriş.";
        public static string UserRegistered = "Kullanıcı Kayıt Edildi.";
        public static string UserNotFound = "Kullanıcı Bulunamadı.";
        public static string PasswordError = "Şifre Hatalı.";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Zaten Mevcut.";
        public static string AccessTokenCreated = "Erişim Token'ı Oluşturuldu";


        #endregion

    }
}
