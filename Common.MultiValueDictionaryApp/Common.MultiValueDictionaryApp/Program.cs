// See https://aka.ms/new-console-template for more information
using Common.MultiValueDictionaryApp.Implementations;
using Common.MultiValueDictionaryApp.Interfaces;
using Common.MultiValueDictionaryApp.Constants;
using Common.MultiValueDictionaryApp.Wrappers;
using Common.MultiValueDictionaryApp.Exceptions;

string inputSeperator = " ";
IMultiValueDictionary<string, string> dict = null;

Console.WriteLine(UIMessages.ChooseMultiValueDictionaryType + Environment.NewLine);
Console.WriteLine(UIMessages.MultiValueDictionaryTypeOptions);

while (true)
{
    int dictionaryType = -1;

    try
    {
        dictionaryType = Convert.ToInt32(Console.ReadLine());
        dict = MultiValueDictionaryFactory.GetInstance<string, string>((MultiValueDictionaryType)dictionaryType);
    }
    catch(UnSupportedDictionaryTypeException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(UIMessages.InvalidInput);
    }

    if (dict != null)
    {
        break;
    }

}

while (true)
{
    Console.WriteLine(Environment.NewLine + UIMessages.EnterInput);
    var input = Console.ReadLine();
    var InputParams = input == null ? null : input.Split(inputSeperator);
    var operation = (InputParams == null || InputParams[0] == null)
        ? null : InputParams[0].Trim().ToUpper();
    var key = (InputParams == null || InputParams.Length < 2 || InputParams[1] == null)
        ? null :  InputParams[1].Trim();
    var value = (InputParams == null || InputParams.Length < 3 || InputParams[2] == null)
        ? null : InputParams[2].Trim();
    if (!ConsoleWrapper.ValidateInput(operation, key, value))
    {
        Console.WriteLine(UIMessages.InvalidInput);
        continue;
    }
    switch (operation)
    {
        case Operations.Keys:
            ConsoleWrapper.GetKeys(dict);
            break;
        case Operations.Members:
            ConsoleWrapper.GetMembers(dict, key);
            break;
        case Operations.Add:
            ConsoleWrapper.Add(dict, key, value);
            break;
        case Operations.Remove:
            ConsoleWrapper.Remove(dict, key, value);
            break;
        case Operations.RemoveAll:
            ConsoleWrapper.RemoveAll(dict, key);
            break;
        case Operations.Clear:
            dict.Clear();
            ConsoleWrapper.ShowSuccessMessage(UIMessages.Cleared);
            break;
        case Operations.KeyExists:
            ConsoleWrapper.ShowSuccessMessage(dict.KeyExists(key).ToString());
            break;
        case Operations.MemberExists:
            ConsoleWrapper.ShowSuccessMessage(dict.MemberExists(key, value).ToString());
            break;
        case Operations.AllMembers:
            ConsoleWrapper.AllMembers(dict);
            break;
        case Operations.Items:
            ConsoleWrapper.Items(dict);
            break;
        case Operations.Stop:
            return;
        default:
            ConsoleWrapper.ShowErrorMessage(UIMessages.InvalidOperation);
            break;
    }
    Console.WriteLine();
}