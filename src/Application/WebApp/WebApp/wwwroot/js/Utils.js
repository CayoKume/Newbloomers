function downloadFile(mimeType, base64String, fileName) {
    const link = document.createElement("a");
    link.href = `data:${mimeType};base64,${base64String}`;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

window.abrirAbas = function (urls) {
    for (let i = 0; i < urls.length; i++) {
        const win = window.open();
        if (win) {
            win.document.write(
                `<iframe src="${urls[i]}" type="application/pdf" width="100%" height="100%"></iframe>`
            );
        } else {
            console.warn("Popup bloqueado para:", urls[i]);
        }
    }
}
