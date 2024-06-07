using Newtonsoft.Json;
using System.Collections.Generic;

namespace admin
{
    public class Store
    {
        static private Store? _instance;
        static public Store Instance
        {
            get
            {
                _instance ??= new Store();

                return _instance;
            }
        }

        private Dictionary<string, dynamic> _state = [];
        public dynamic? State => _state;

        public void LoadState()
        {
            if (System.IO.File.Exists("State.json")) {
                var state = System.IO.File.ReadAllText("State.json");
                _state = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(state) ?? [];
            } else {
                _state = [];
            }
        }

        public void SaveState()
        {
            var state = System.Text.Json.JsonSerializer.Serialize(_state);
            System.IO.File.WriteAllText("State.json", state);
        }

        public dynamic? GetStateItem(string key)
        {
            try
            {
                return _state[key];
            }
            catch
            {
                return null;
            }
        }

        public void SetStateItem(string key, dynamic item)
        {
            _state[key] = item;

            SaveState();
        }

        public void RemoveStateItem(string key)
        {
            _state.Remove(key);
            SaveState();
        }
    }
}
