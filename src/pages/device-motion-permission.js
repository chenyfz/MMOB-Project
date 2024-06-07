export async function getDeviceMotionPermission() {
    if (typeof(DeviceMotionEvent) !== 'undefined' &&
        typeof(DeviceMotionEvent.requestPermission) === 'function' ) {
        const res = await DeviceOrientationEvent.requestPermission()
        return res === 'granted'
    } else {
        return true
    }
}