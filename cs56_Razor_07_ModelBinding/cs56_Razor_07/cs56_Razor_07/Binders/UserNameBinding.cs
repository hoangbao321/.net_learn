using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/**
 * chuyển tên thành chữ in hoa
 * Tên không được chứa xxx
 * Cắt khoảng trắng ở đầu và cuối
 */

public class UserNameBinding : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
            throw new ArgumentException("bindingContext");

        string modelName = bindingContext.ModelName;//key
        // đọc giá trị gửi đến
        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }
        string value = valueProviderResult.FirstValue;
        if (string.IsNullOrEmpty(value))
            return Task.CompletedTask;

        //Binding
        string s = value.ToUpper();
        if (s.Contains("XXX"))
        {
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
            bindingContext.ModelState.TryAddModelError(modelName, "bo chu xxx ra ");
        }
        s = s.Trim();
        bindingContext.ModelState.SetModelValue(modelName, s, s);
        bindingContext.Result = ModelBindingResult.Success(s);
        return Task.CompletedTask;
    }
}


