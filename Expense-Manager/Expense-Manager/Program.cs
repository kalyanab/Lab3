using System.Text.Json.Serialization;
using System.Text.Json;
using WinForms_Expense_Manager.Schemas;
namespace WinForms_Expense_Manager.Classes
{
@@ -14,7 +13,11 @@ public class ExpenseManager
        #region Fields
        public readonly string DataFileName = "expense-manager-data.json";
    private List<Entry> _entries = new();
    private Dictionary<Guid, string> _categories = new()
        {
            {Guid.Empty, "No category"},
        };
    private string _currencySign = "$";
    #endregion

    #region Properties
    /// <summary>
    /// Provides a copy of the Entries stored in this object.
    /// </summary>
    [JsonInclude]
    public List<Entry> Entries { get => new(_entries); }
    /// <summary>
    /// Provides a copy of the Categories stored in the Expense Manager object.
    /// </summary>
    [JsonInclude]
    public Dictionary<Guid, string> Categories { get => new(_categories); }
    [JsonInclude]
    public string CurrencySign
    {
        get => _currencySign;
        set
        {
            if (string.IsNullOrEmpty(value))
                return;
            _currencySign = value;
        }
    }
    #endregion

    #region Constructors
    public ExpenseManager()
    {
    }
        #endregion

@@ -93,12 +107,13 @@ public bool LoadData()
            string json = sr.ReadToEnd();

    ExpenseManagerDataSchema? data = JsonSerializer.Deserialize<ExpenseManagerDataSchema>(json);
      if(data == null || data.Entries == null || data.Categories == null || data.CurrencySign == null)
            {
                return false;
            }
_entries = new List<Entry>(data.Entries);
_categories = new Dictionary<Guid, string>(data.Categories);
CurrencySign = data.CurrencySign;
return true;
        }
        public void AddTask(Entry e)
{
    if (!_categories.ContainsKey(e.CategoryId))
        throw new ArgumentException("Category ID is not registered within the Expense Manager instance.");
    _entries.Add(e);
}
public Guid AddNewTask(string title, string description, decimal value)
{
    Entry e = new(title, description, value);
    AddTask(e);
    return e.Id;
}
public Guid AddCategory(string categoryName)
{
    if (CategoryNameExists(categoryName))
        throw new ArgumentException("Category name is already registered within the Expense Manager instance.");
    Guid categoryId = Guid.NewGuid();
    _categories.Add(categoryId, categoryName);
    return categoryId;
}
public Entry[] EntriesFromRange(DateTime fromDate, DateTime toDate)
{
    var selected = from s in _entries
                   where s.CreatedAt > fromDate && s.CreatedAt < toDate
                   select s;
    return selected.ToArray();
}
        #endregion
    }
}