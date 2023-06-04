using CountriesInformer.Models;
using Microsoft.EntityFrameworkCore;

namespace CountriesInformer.Extensions;

public static class DataSeeder
{
    public static void CountriesSeed(this ModelBuilder builder)
    {
        builder.Entity<Country>()
            .HasData(new Country
            {
                Id = 1,
                Name = "Kazakhstan",
                CapitalCity = "Astana",
                OfficialLanguage = "Kazakh"
            });
        builder.Entity<Country>()
            .HasData(new Country
            {
                Id = 2,
                Name = "Uzbekistan",
                CapitalCity = "Tashkent",
                OfficialLanguage = "Uzbek"
            });
        builder.Entity<Country>()
            .HasData(new Country
            {
                Id = 3,
                Name = "Georgia",
                CapitalCity = "Tbilisi",
                OfficialLanguage = "Georgian"
            });
        builder.Entity<Country>()
            .HasData(new Country
            {
                Id = 4,
                Name = "Afghanistan",
                CapitalCity = "Kabul",
                OfficialLanguage = "Pashto"
            });
        builder.Entity<Country>()
            .HasData(new Country
            {
                Id = 5,
                Name = "Iran",
                CapitalCity = "Tehran",
                OfficialLanguage = "Iranian"
            });
        builder.Entity<Country>()
            .HasData(new Country
            {
                Id = 6,
                Name = "Saudi Arabia",
                CapitalCity = "Riyadh",
                OfficialLanguage = "Arabic"
            });
        builder.Entity<Country>()
            .HasData(new Country
            {
                Id = 7,
                Name = "Pakistan",
                CapitalCity = "Islamabad",
                OfficialLanguage = "Urdu"
            });
        builder.Entity<Country>()
            .HasData(new Country
            {
                Id = 8,
                Name = "Algeria",
                CapitalCity = "Algiers",
                OfficialLanguage = "Arabic"
            });
        builder.Entity<Country>()
            .HasData(new Country
            {
                Id = 9,
                Name = "Turkmenistan",
                CapitalCity = "Ashgabat",
                OfficialLanguage = "Turkmen"
            });
        builder.Entity<Country>()
            .HasData(new Country
            {
                Id = 10,
                Name = "Mongolia",
                CapitalCity = "Ulaanbaatar",
                OfficialLanguage = "Mongolian"
            });
    }
}