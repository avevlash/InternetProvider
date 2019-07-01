using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternetProvider.Web.Models
{
    public class AddServiceViewModel
    {
        [Display(Name = "Название услуги")]
        [Required(ErrorMessage = "Введите название услуги")]
        public string ServiceName { get; set; }
        [Display(Name = "Описание услуги")]
        [Required(ErrorMessage = "Введите описание услуги")]
        public string Properties { get; set; }
        [Display(Name = "Тарифы")]
        [ListValidation(1, ErrorMessage = "Введите хотя бы один тариф")]
        public List<TariffViewModel> TariffList { get; set; }
    }
    public class EditServiceViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Название услуги")]
        [Required(ErrorMessage = "Введите название услуги")]
        public string ServiceName { get; set; }
        [Display(Name = "Описание услуги")]
        [Required(ErrorMessage = "Введите описание услуги")]
        public string Properties { get; set; }
        [Display(Name = "Тарифы")]
        [ListValidation(1, ErrorMessage = "Введите хотя бы один тариф")]
        public List<EditTariffViewModel> TariffList { get; set; }
    }

    public class EditTariffViewModel
    {
        public string Id { get; set; }
        public double Price { get; set; }
        public string TariffName { get; set; }
        public string TariffProperties { get; set; }
        public int ValidityPeriod { get; set; }
    }
    public class TariffViewModel
    {
        public double Price { get; set; }
        public string TariffName { get; set; }
        public string TariffProperties { get; set; }
        public int ValidityPeriod { get; set; }
    }

    #region Helpers
    public class ListValidation : ValidationAttribute
    {
        private readonly int _minElements;
        public ListValidation(int minElements)
        {
            _minElements = minElements;
        }
        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list != null)
            {
                return list.Count >= _minElements;
            }
            return false;
        }
    }
    #endregion
}