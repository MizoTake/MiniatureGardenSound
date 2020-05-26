using Cysharp.Threading.Tasks;

namespace MiniatureGardenSound.Provider.Interface
{
    public interface IAddressableProvidable
    {
        UniTask<T> LoadAsync<T>(string key);
        void Release<T>(T obj);
    }
}