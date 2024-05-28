
using Assets.Domain.Entities;
using Assets.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Users.Commands.UpdateUser;


    public class UpdateUserDetailsHandler(
        ILogger<UpdateUserDetailsHandler> logger,
        IUserContext userContext,
        IUserStore<User> userStore) : IRequestHandler<UpdateUserDetailsCommand>
    {

    public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation("Updating user: {@userId}, with {@Request}",user.Id, request);

        var dbUser = await userStore.FindByIdAsync(user.Id, cancellationToken) ?? throw new NotFoundException(nameof(User), user.Id);

        dbUser.Nationality = request.Nationality;  
        dbUser.DateOfBirth = request.DateOfBirth;

        await userStore.UpdateAsync(dbUser, cancellationToken);
  
    }
    }

