function AddStylesheet(basePath) {
    const link = document.createElement('link');
    link.rel = "stylesheet";
    link.href = basePath + "/maplibre-gl.css";
    document.head.appendChild(link)
}

const instances = {};

const MapLibre = {
    create: function (options, dotnetReference) {
        
        const map = new maplibregl.Map(options);
        instances[options.container] = map;

        map.on('load', function () {
            dotnetReference.invokeMethodAsync("OnLoadCallback")
        });
    },
    addLayer: function (container, layer, beforeId) {
        instances[container].addLayer(layer, beforeId);
    },
    addSource: function (container, id, source) {
        instances[container].addSource(id, source);
    },
    fitBounds: function (container, bounds) {
        const llb = new maplibregl.LngLatBounds(bounds.sw, bounds.ne);
        instances[container].fitBounds(llb);
    },
    getCenter: function (container) {
        return instances[container].getCenter();
    },
    project: function (container, coordinate) {
        return instances[container].project(coordinate);
    },
    resize: function (container) {
        instances[container].resize();
    },
    setFeatureState: function (container, feature, state) {
        instances[container].setFeatureState(feature, state);
    },
    on: (container, eventType, dotnetReference, args) => {
        if (args === undefined) {
            instances[container].on(eventType, function (e) {
                e.target = null; // Remove map to prevent circular references.
                const result = JSON.stringify(e);
                dotnetReference.invokeMethodAsync('Invoke', result)
            })
        }
        else {
            instances[container].on(eventType, args, function (e) {
                e.target = null; // Remove map to prevent circular references.
                const result = JSON.stringify(e);
                dotnetReference.invokeMethodAsync('Invoke', result)
            })
        }
    }
}

const popups = {};

const MapLibrePopup = {
    create: function (popupId, options) {
        popups[popupId] = new maplibregl.Popup(options);
    },
    addClassName: function (popupId, className) {
        popups[popupId].addClassName(className);
    },
    addTo: function (popupId, mapId) {
        const map = instances[mapId];
        popups[popupId].addTo(map);
    },
    getLngLat: function (popupId) {
        return popups[popupId].getLngLat();
    },
    getMaxWidth: function (popupId) {
        return popups[popupId].getMaxWidth();
    },
    isOpen: function (popupId) {
        return popups[popupId].isOpen();
    },
    remove: function (popupId) {
        popups[popupId].remove();
    },
    removeClassName: function (popupId, className) {
        popups[popupId].removeClassName(className);
    },
    setLngLat: function (popupId, lnglat) {
        popups[popupId].setLngLat(lnglat);
    },
    setText: function (popupId, text) {
        popups[popupId].setText(text);
    },
    toggleClassName: function (popupId, className) {
        return popups[popupId].toggleClassName(className);
    },
    on: (popupId, eventType, dotnetReference) => {
        popups[popupId].on(eventType, function () {
            dotnetReference.invokeMethodAsync('InvokeWithoutArgs')
        })
    }
}

export { MapLibre, MapLibrePopup, AddStylesheet };