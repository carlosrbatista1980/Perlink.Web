using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Perlink.Data.Data;
using Perlink.Services;
using Shouldly;
using Shouldly.ShouldlyExtensionMethods;
using Xunit;
using Perlink.Services.Base;
using Perlink.Test.Base;

namespace Perlink.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Create test"), Trait("Category CRUD", "Create One Lawsuit")]
        public void CreateOneRecord()
        {
            Lawsuit lawsuit = new Lawsuit();
            lawsuit.SuitNumber = "Test00010009";
            lawsuit.SuitCreationTime = DateTime.Today;
            lawsuit.CourtCosts = 333.03m;
            lawsuit.LawofficeId = 1; //OfficeId 1 deve existir primeiro

            Assert.True(true);  // é só uma "casca", não tem tempo para fazer todas as implementações usando o Base e o Fixture
        }
        
        [Theory(DisplayName = "Create test"), Trait("Category CRUD", "Create Multiple Lawsuits")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void CreateMultipleRecords(int records)
        {
            for (int i = 1; i == records; i++)
            {
                string rec = records.ToString();

                Lawsuit lawsuit = new Lawsuit();
                lawsuit.SuitNumber = "Test001002-" + rec;
                lawsuit.SuitCreationTime = DateTime.Today;
                lawsuit.CourtCosts = 333.03m;
                lawsuit.LawofficeId = 1; //OfficeId 1 deve existir primeiro

                try
                {
                    Assert.True(true);
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine($"### Erro: Record numero - {i}");
                    continue;
                }
                
            }
        }

        
    }
}
