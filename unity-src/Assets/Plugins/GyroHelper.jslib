mergeInto(LibraryManager.library, {
    StartListeningGyro: function () {
        window.addEventListener("deviceorientation", (event) => {
            this.gamma = event.gamma
        }, true);
    },
    
    GetGyroMilliGamma: function () {
        return Math.ceil(this.gamma * 1000);
    },
});