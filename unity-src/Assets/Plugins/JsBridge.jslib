mergeInto(LibraryManager.library, {
    GetGameVersionJSBridge: function () {
        const returnStr = window.jsbridge.getGameVersion()
        const bufferSize = lengthBytesUTF8(returnStr) + 1;
        const buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    
    ReportDataJSBridge: function (jsonStr) {
        return window.jsbridge.reportData(UTF8ToString(jsonStr))
    }
});