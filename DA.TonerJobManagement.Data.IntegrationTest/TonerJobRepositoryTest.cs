using System;
using System.Collections.Generic;
using System.Linq;
using DA.TonerJobManagement.Core.Aggregates.Models;
using DA.TonerJobManagement.Data.Repositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace DA.TonerJobManagement.Data.Test
{
    public class TonerJobRepositoryTest
    {
        public void New_Job__Should_Get_Inserted_Without_Error()
        {
            //Arrange
            var context = new TonerJobContext();
            var jobRepository = new TonerJobRepository(context);
            var tonnerRepository = new TonerRepository(context);
            var tonerJob = TonerJob.Create(1, new List<Toner>() { tonnerRepository.GetTonerById(1) }, 1, 1, DateTime.Now, DateTime.Now.AddDays(1), new List<PurchaseItem>(), "", 0);

            //Act
            Action action = () => jobRepository.Insert(tonerJob);

            //Assert
            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void Repo_Should_Get_Results()
        {
            //Arrange
            var context = new TonerJobContext();
            var jobRepository = new TonerJobRepository(context);


            //Act
            var data = jobRepository.Get().Take(1);

            //Assert
            data.Should().HaveCount(1);
        }
    }
}
