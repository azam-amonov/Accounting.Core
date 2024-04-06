using System.Linq.Expressions;
using MicrosAccounting.Api.Brokers.StorageBrokers;
using MicrosAccounting.Api.Models.Users;
using MicrosAccounting.Api.Services.Foundations.Users;
using Moq;
using Tynamix.ObjectFiller;
using Xeptions;

namespace MicrosAccounting.UnitTest.Foundation.Users;

public class UserServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly IUserService usrerService;

    public UserServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.usrerService = new UserService(
            storageBroker: this.storageBrokerMock.Object);
    }

    private static Expression<Func<Xeption, bool>> 
        SameExceptionAs(Xeption expectedException) => 
        actualException => actualException.SameExceptionAs(expectedException);
    
    private static int GetRandomNumber() =>
        new IntRange(min: 2, max: 9).GetValue();

    private static User CreateRandomUser() =>
        CreateRandomUserFiller().Create();

    private static IQueryable<User> CreateRandomUsers() =>
        CreateRandomUserFiller().Create(count: GetRandomNumber()).AsQueryable();

    private static Filler<User> CreateRandomUserFiller() =>
        new Filler<User>();
}