using Fluxor;

namespace Serti.Client.Pages.Identity.Store
{
    public record IdentityState
    {
        public string Email { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }


    public class IdentityFeature : Feature<IdentityState>
    {
        public override string GetName()
        {
            return "Identity";
        }

        protected override IdentityState GetInitialState()
        {
            return new IdentityState
            {
                Email = "",
                FirstName = "",
                LastName = "",
            };
        }
    }

    public static class IdentityReducers
    {

        [ReducerMethod]
        public static IdentityState OnSetForecasts(IdentityState state, IdentitySetValueAction action)
        {
            return state with
            {
                Email = action.Email,
                FirstName = action.FirstName,
                LastName = action.LastName,
            };
        }
    }

    public class IdentitySetValueAction
    {
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public IdentitySetValueAction(string email, string firstName, string lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }

}
