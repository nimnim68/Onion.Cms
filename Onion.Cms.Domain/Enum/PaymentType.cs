using System.ComponentModel.DataAnnotations;

namespace Onion.Cms.Domain.Enum
{
    public enum PaymentType
    {
        [Display(Name = "کارت به کارت")]
        DebitCart = 1,
        [Display(Name = "آنلاین")]
        Online = 2,
        [Display(Name = "درب منزل")]
        Cache = 3
    }
    public enum OrderState
    {
        [Display(Name = "در حال پردازش")]
        Processing = 1,
        [Display(Name = "تایید شده")]
        Confirm = 2,
        [Display(Name = "تحویل داده شده")]
        Delivered = 3,
        [Display(Name = "لغو شده")]
        Cancelled = 4
    }

    public enum OrderPostType
    {
        [Display(Name = "ارسال با پیک موتوری (ویژه شهر تهران) 28,000 تومان تا محل شما")]
        Motor = 1,
        [Display(Name = "پست پیشتاز (سراسر کشور) 20,000 تومان")]
        Pishtaz = 2
    }

}