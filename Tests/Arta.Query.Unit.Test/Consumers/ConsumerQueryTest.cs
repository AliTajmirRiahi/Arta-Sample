using Arta.Query.CunsumerQueries;
using Arta.Query.Model.ConsumerQueryModel;
using Dapper;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Dapper;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Arta.Query.Unit.Test.Consumers
{
    public class ConsumerQueryTest
    {
        [Fact]
        public void Get_Consumer_By_Id_Success()
        {
            //Arrange
            var expected = new ConsumerPermissionModel
            {
                Id = 1,
                Domain = "king.com",
                SubDomain = "king",
                Enable = true,
                Description = "test",
            };

            var connection = new Mock<IDbConnection>();

            connection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<ConsumerPermissionModel>(It.IsAny<string>(), null, null, null, null))
                      .Returns(expected);

            connection.set

            var configuration = Substitute.For<IConfiguration>();
            var consumerQueryFacade = new Mock<ConsumerQueryFacade>(connection.Object , configuration);

            //var actual = connection.Object.QueryFirstOrDefault<ConsumerPermissionModel>("", null, null, null, null);

            var actual = consumerQueryFacade.Object.GetCunsumersById(1).Result;

            Assert.Equal(expected.Id, actual.Id);
        }
    }
}


////Arrange
//var fakeCunsumer = new ConsumerPermissionModel
//{
//    Id = 1,
//    Domain = "king.com",
//    SubDomain = "king",
//    Enable = true,
//    Description = "test",
//};
//var configuration = Substitute.For<IConfiguration>();

//var connection = new SqlConnection("Data Source=.;initial catalog=ArtaSample;Integrated Security=True;");

//Mock<IConsumerQueryFacade> _queryMock = new Mock<IConsumerQueryFacade>(connection, configuration);

//_queryMock.Setup(x => x.GetCunsumersById(1)).Returns(Task.FromResult(fakeCunsumer));

////Act
//var actualCunsumer = await _queryMock.Object.GetCunsumersById(1);

////Assert
//Assert.Equal(fakeCunsumer.Id, actualCunsumer.Id);
//Assert.Equal(fakeCunsumer.Description, actualCunsumer.Description);
//Assert.Equal(fakeCunsumer.Domain, actualCunsumer.Domain);
//Assert.Equal(fakeCunsumer.SubDomain, actualCunsumer.SubDomain);
//Assert.Equal(fakeCunsumer.Enable, actualCunsumer.Enable);