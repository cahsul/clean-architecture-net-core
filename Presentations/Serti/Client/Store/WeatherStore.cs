using System.Net.Http.Json;
using Fluxor;

namespace Serti.Client.Store
{

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    public record WeatherState
    {
        public bool Initialized { get; init; }
        public bool Loading { get; init; }
        public WeatherForecast[] Forecasts { get; init; }
    }


    public class WeatherFeature : Feature<WeatherState>
    {
        public override string GetName()
        {
            return "Weather";
        }

        protected override WeatherState GetInitialState()
        {
            return new WeatherState
            {
                Initialized = false,
                Loading = false,
                Forecasts = Array.Empty<WeatherForecast>()
            };
        }
    }

    public static class WeatherReducers
    {
        [ReducerMethod]
        public static WeatherState OnSetForecasts(WeatherState state, WeatherSetForecastsAction action)
        {
            return state with
            {
                Forecasts = action.Forecasts,
                Loading = false
            };
        }

        //[ReducerMethod]
        //public static WeatherState OnSetLoading(WeatherState state, WeatherSetLoadingAction action)
        //{
        //    return state with
        //    {
        //        Loading = action.Loading
        //    };
        //}

        [ReducerMethod(typeof(WeatherLoadForecastsAction))]
        public static WeatherState OnLoadForecasts(WeatherState state)
        {
            return state with
            {
                Loading = true
            };
        }

        [ReducerMethod(typeof(WeatherSetInitializedAction))]
        public static WeatherState OnSetInitialized(WeatherState state)
        {
            return state with
            {
                Initialized = true
            };
        }

    }

    public class WeatherEffects
    {
        private readonly HttpClient _http;

        private readonly IState<CounterState> _counterState;

        public WeatherEffects(HttpClient http, IState<CounterState> counterState)
        {
            _http = http;
            _counterState = counterState;
        }

        [EffectMethod(typeof(WeatherLoadForecastsAction))]
        public async Task LoadForecasts(IDispatcher dispatcher)
        {
            //dispatcher.Dispatch(new WeatherSetLoadingAction(true));
            //var forecasts = await _http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
            //dispatcher.Dispatch(new WeatherSetForecastsAction(forecasts));
            //dispatcher.Dispatch(new WeatherSetLoadingAction(false));
            Console.WriteLine("kelimatan 10 => WeatherLoadForecastsAction ");
            dispatcher.Dispatch(new WeatherSetForecastsAction(null));
        }

        [EffectMethod(typeof(CounterIncrementAction))]
        public async Task LoadForecastsOnIncrement(IDispatcher dispatcher)
        {
            // every tenth increment
            if (_counterState.Value.CurrentCount % 10 == 0)
            {
                dispatcher.Dispatch(new WeatherLoadForecastsAction());
            }
        }
    }


    public class WeatherLoadForecastsAction { }
    public class WeatherSetInitializedAction { }
    public class WeatherSetForecastsAction
    {
        public WeatherForecast[] Forecasts { get; }

        public WeatherSetForecastsAction(WeatherForecast[] forecasts)
        {
            Forecasts = forecasts;
        }
    }

    public class WeatherSetLoadingAction
    {
        public bool Loading { get; }

        public WeatherSetLoadingAction(bool loading)
        {
            Loading = loading;
        }
    }
}
