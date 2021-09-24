using System;
using System.Collections.Generic;
using System.Text;

namespace EmreCrm.Core.Helper
{
    /// <summary>
    /// Durum barı için buton tipi belirlemeye
    /// </summary>
    public enum StatusBarType
    {
        Success = 1,
        Error = 2,
        Information = 3
    }

    public static class GridHelper
    {
        /// <summary>
        /// Grid içerisinde yer alan aksiyonlar bölümün HTML çıktısını otomatik üreten metod
        /// </summary>
        /// <param name="id">İşlem yapılacak benzersiz id</param>
        /// <param name="edit">Düzenleme özelliği açılsın mı ?</param>
        /// <param name="editUrl">Düzenleme özelliği sayfası ("/" ile bitirmeyiniz)</param>
        /// <param name="delete">Silme özelliği açılsın mı ?</param>
        /// <param name="deleteUrl">Silme işlemi için istek atılıcak adres</param>
        /// <param name="deleteRedirectUrl">Silme işleminden sonra yönlendirme yapılacak adres</param>
        /// <param name="detail">Detay özelliği açılsın mı ?</param>
        /// <param name="detailUrl">Detay adresi</param>
        /// <returns>string</returns>
        public static string HtmlGridActionsBuilder(int id, bool edit = false, string editUrl = "", bool delete = false, string deleteUrl = "", string deleteRedirectUrl = "", bool detail = false, string detailUrl = "", bool check = false, bool checkStatus = false, string checkUrl = "")
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                if (check)
                {
                    sb.Append($"<a href=\"#\" class=\"m-portlet__nav-link btn m-btn m-btn--hover-success m-btn--icon m-btn--icon-only m-btn--pill\" title=\"{(checkStatus ? "Okundu" : "Okunmadı")}\" onClick=\"readOffer('{id}')\"><i class=\"la {(checkStatus ? "la-check" : "la-close")}\"></i></a>");
                }

                if (edit == true)
                {
                    sb.Append($"<a href='{editUrl}/{id}' class='m-portlet__nav-link btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill' title='Düzenle'><i class='la la-edit'></i></a>");
                }

                if (detail == true)
                {
                    sb.Append($"<a href='{detailUrl}/{id}' class='m-portlet__nav-link btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill' title='Detay'><i class='la la-search'></i></a>");
                }

                if (delete == true)
                {
                    sb.Append($"<a href=\"#\" class=\"m-portlet__nav-link btn m-btn m-btn--hover-danger m-btn--icon m-btn--icon-only m-btn--pill\" title=\"Sil\" onClick=\"$.App.deleteRow('{id}', '{deleteUrl}', '{deleteRedirectUrl}')\"><i class=\"la la-trash\"></i></a>");
                }

                return sb.ToString();
            }
            catch (System.Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Durum barı oluşturma metodu
        /// </summary>
        /// <param name="type">Bar tipi</param>
        /// <param name="text">İç yazı</param>
        /// <returns></returns>
        public static string StatusBarBuilder(StatusBarType type, string text)
        {
            try
            {
                string pattern = $"<span class=\"classType\">{text}</span>";

                if (type == StatusBarType.Success)
                    pattern = pattern.Replace("classType", "m-badge  m-badge--success m-badge--wide");
                else if (type == StatusBarType.Error)
                    pattern = pattern.Replace("classType", "m-badge  m-badge--danger m-badge--wide");
                else if (type == StatusBarType.Information)
                    pattern = pattern.Replace("classType", "m-badge  m-badge--info m-badge--wide");
                else
                    pattern = pattern.Replace("classType", "m-badge  m-badge--success m-badge--wide");

                return pattern;
            }
            catch (System.Exception)
            {
                return string.Empty;
            }
        }
    }
}
