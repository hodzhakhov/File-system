using System.Collections.Generic;
using System.Linq;

namespace FS.RequestIterators;

public class RequestIterator
{
    private readonly List<string> _request;
    private int _index;

    public RequestIterator(IEnumerable<string> request)
    {
        _request = request.ToList();
        _index = 0;
    }

    public string Current()
    {
        return _index < _request.Count ? _request[_index] : string.Empty;
    }

    public bool Next()
    {
        _index++;
        return _index < _request.Count;
    }

    public void Reset()
    {
        _index = 0;
    }
}
