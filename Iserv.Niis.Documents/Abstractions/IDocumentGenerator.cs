using System.Collections.Generic;
using Iserv.Niis.FileConverter;

namespace Iserv.Niis.Documents.Abstractions
{
    public interface IDocumentGenerator
    {
        /// <summary>
        ///     ������ �������� �� �������
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        GeneratedDocument Process(Dictionary<string, object> parameters);
    }
}