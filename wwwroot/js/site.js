// Copia texto al portapapeles, con alternativa para navegadores antiguos o sin permiso.
window.copyToClipboard = function (text) {
    // Si el navegador soporta la API de portapapeles, la usa
    if (navigator.clipboard && navigator.clipboard.writeText) {
        
        return navigator.clipboard.writeText(text);
    }
// Si no, creamos un elemento de texto temporal para copiar el contenido.
    const el = document.createElement('textarea');
    el.value = text;
    el.style.position = 'fixed';
    el.style.opacity = '0';
    document.body.appendChild(el);
    el.select();
    try { document.execCommand('copy'); } catch (e) { }
    document.body.removeChild(el);
};

// Abre una URL en una pestaña nueva.
window.openUrl = function (url) {
    
    window.open(url, '_blank', 'noopener');
};