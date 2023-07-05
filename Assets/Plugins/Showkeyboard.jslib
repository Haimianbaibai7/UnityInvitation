 mergeInto(LibraryManager.library, {

    StringReturnValueFunction: function ()
    {
        var returnStr = "111";
        var buffer = _malloc(lengthBytesUTF8(returnStr) + 1);
        writeStringToMemory(returnStr,buffer);
        return buffer;
    },

    ShowKeyboard: function (str)   //这个就是呼出浏览器默认提示框的方法
    {
        var returnStr = prompt("", Pointer_stringify(str)); //呼出提示框方法，具体百度
        if(returnStr == undefined)
        {
           return "222";
        }
        var buffer = _malloc(lengthBytesUTF8(returnStr) + 1);
         writeStringToMemory(returnStr,buffer);
        return buffer;
    },

});
