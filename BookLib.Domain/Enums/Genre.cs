using System;
using System.ComponentModel.DataAnnotations;

namespace BookLib.Domain.Enums
{
    public enum Genre
    {
        [Display(Name = "Art & Design")]
        Art,

        [Display(Name = "Biographies & Memoirs")]
        Biographies,

        [Display(Name = "Business & Economics")]
        Business,

        [Display(Name = "Comics & Graphic Novels")]
        Comics,

        [Display(Name = "Comedy / Humor")]
        Comedy,

        [Display(Name = "Cooking & Food")]
        Cooking,

        [Display(Name = "Classic Literature")]
        Classic,

        [Display(Name = "Crafts & Hobbies")]
        Crafts,

        [Display(Name = "Education")]
        Education,

        [Display(Name = "Entertainment")]
        Entertainment,

        [Display(Name = "Fantasy")]
        Fantasy,

        [Display(Name = "Fiction")]
        Fiction,

        [Display(Name = "Gardening")]
        Garden,

        [Display(Name = "Health & Wellness")]
        Health,

        [Display(Name = "History")]
        History,

        [Display(Name = "Home & Lifestyle")]
        Home,

        [Display(Name = "Horror")]
        Horror,

        [Display(Name = "Children's / Kids")]
        Kids,

        [Display(Name = "Literature")]
        Literature,

        [Display(Name = "Medical")]
        Medical,

        [Display(Name = "Mystery & Crime")]
        Mystery,

        [Display(Name = "Parenting & Family")]
        Parenting,

        [Display(Name = "Religion & Spirituality")]
        Religion,

        [Display(Name = "Romance")]
        Romance,

        [Display(Name = "Science Fiction")]
        SciFi,

        [Display(Name = "Science")]
        Science,

        [Display(Name = "Self Help / Personal Growth")]
        SelfHelp,

        [Display(Name = "Sports")]
        Sports,

        [Display(Name = "Technology")]
        Technology,

        [Display(Name = "Travel & Adventure")]
        Travel,

        [Display(Name = "True Crime")]
        TrueCrime,

        [Display(Name = "Westerns")]
        Westerns,

        [Display(Name = "Young Adult")]
        YoungAdult
    }
}
