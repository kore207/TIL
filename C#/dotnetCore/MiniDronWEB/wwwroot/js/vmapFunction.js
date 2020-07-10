var customLayersource = new ol.source.Vector({
    id: "customLayersourceId"
});
customLayersource.set("name", "customLayersourceName");

var customLayerVector = new ol.layer.Vector({ // 사용자 제한구역  벡터 
    id: "customLayervectorId",
    source: customLayersource,
    style: new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(165, 42, 42, 0.2)'
        }),
        stroke: new ol.style.Stroke({
            color: '#ffcc33',
            width: 2
        }),
        image: new ol.style.Circle({
            radius: 7,
            fill: new ol.style.Fill({
                color: '#ffcc33'
            })
        })
    })
});
customLayerVector.set("name", "customLayervectorName");
customLayerVector.setZIndex(11);
var sketch;

var helpTooltipElement;

var helpTooltip;

var measureTooltipElement;

var measureTooltip;

var continuePolygonMsg = '더블 클릭하여 생성을 완료 합니다.';

//createMeasureTooltip();
//createHelpTooltip();



var pointerMoveHandler = function (evt) {
    if (evt.dragging) {
        return;
    }
   
    var helpMsg = '클릭하여 제한 영역을 생성합니다.';

    if (sketch) {
        var geom = (sketch.getGeometry());
        if (geom instanceof ol.geom.Polygon) {
            helpMsg = continuePolygonMsg;
        } else if (geom instanceof ol.geom.LineString) {
            helpMsg = continueLineMsg;
        }
    }
    
    helpTooltipElement.innerHTML = helpMsg;
    helpTooltip.setPosition(evt.coordinate);

    helpTooltipElement.classList.remove('hidden');
};

vmap.addLayer(customLayerVector);


//vmap.on('pointermove', pointerMoveHandler);
let moveHandler;

//vmap.getViewport().addEventListener('mouseout', function () {
//    helpTooltipElement.classList.add('hidden');
//});

var draw; // global so we can remove it later

var wgs84Sphere = new ol.Sphere(6378137);

var formatArea = function (polygon) {
    
    var area;// = new ol.Sphere.getArea(polygon); //return geometry

    var sourceProj = vmap.getView().getProjection();
    var geom =(polygon.clone().transform(
        sourceProj, 'EPSG:4326'));
    var coordinates = geom.getLinearRing(0).getCoordinates();
    area = Math.abs(wgs84Sphere.geodesicArea(coordinates));


    var output;
    if (area > 10000) {
        output = (Math.round(area / 1000000 * 100) / 100) +
            ' ' + 'km<sup>2</sup>';
    } else {
        output = (Math.round(area * 100) / 100) +
            ' ' + 'm<sup>2</sup>';
    }
    return output;
};

function addInteraction() {
    var type = 'Polygon' ;
    draw = new ol.interaction.Draw({
        source: customLayersource,
        type: type,
        style: new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255, 255, 255, 0.2)'
            }),
            stroke: new ol.style.Stroke({
                color: 'rgba(0, 0, 0, 0.5)',
                lineDash: [10, 10],
                width: 2
            }),
            image: new ol.style.Circle({
                radius: 5,
                stroke: new ol.style.Stroke({
                    color: 'rgba(0, 0, 0, 0.7)'
                }),
                fill: new ol.style.Fill({
                    color: 'rgba(255, 255, 255, 0.2)'
                })
            })
        })
    });
    vmap.addInteraction(draw);

    var listener;
    draw.on('drawstart',
        function (evt) {
            // set sketch
            sketch = evt.feature;
            sketch.set('id', '사용자설정레이어');
            
            var tooltipCoord = evt.coordinate;

            listener = sketch.getGeometry().on('change', function (evt) {
                var geom = evt.target;
                var output;
                if (geom instanceof ol.geom.Polygon) {
                    output = formatArea(geom);
                    tooltipCoord = geom.getInteriorPoint().getCoordinates();
                } else if (geom instanceof ol.geom.LineString) {
                    //output = formatLength(geom);
                    //tooltipCoord = geom.getLastCoordinate();
                }
                measureTooltipElement.innerHTML = output;
                measureTooltip.setPosition(tooltipCoord);
            });
        }, this);

    draw.on('drawend',
        function () {
            measureTooltipElement.className = 'tooltip tooltip-static';
            measureTooltip.setOffset([0, -7]);
            // unset sketch
            sketch = null;
            // unset tooltip so that a new one can be created
            measureTooltipElement = null;
            //createMeasureTooltip();
            ol.Observable.unByKey(listener);

            vmap.removeInteraction(draw);
            vmap.removeOverlay(measureTooltip);
            vmap.removeOverlay(helpTooltip);
            ol.Observable.unByKey(moveHandler);

        }, this);
}

function createHelpTooltip() {
    if (helpTooltipElement) {
        helpTooltipElement.parentNode.removeChild(helpTooltipElement);
    }
    helpTooltipElement = document.createElement('div');
    helpTooltipElement.className = 'tooltip hidden';
    helpTooltip = new ol.Overlay({
        element: helpTooltipElement,
        offset: [15, 0],
        positioning: 'center-left'
    });
    vmap.addOverlay(helpTooltip);
}

function createMeasureTooltip() {
    if (measureTooltipElement) {
        measureTooltipElement.parentNode.removeChild(measureTooltipElement);
    }
    measureTooltipElement = document.createElement('div');
    measureTooltipElement.className = 'tooltip tooltip-measure';
    measureTooltip = new ol.Overlay({
        element: measureTooltipElement,
        offset: [0, -15],
        positioning: 'bottom-center'
    });
    vmap.addOverlay(measureTooltip);
}

//addInteraction();

function loadCustomLayer() {
    var center = vmap.getView().getCenter();
    
    var points = [];
    points.push([center[0], center[1]]);
    points.push([center[0] + 100, center[1] - 100]);
    points.push([center[0] + 150, center[1] - 20]);
    points.push([center[0] + 200, center[1] - 40]);
    points.push([center[0] + 200, center[1] + 20]);
    points.push([center[0] + 200, center[1] + 40]);
    points.push([center[0] + 150, center[1] + 20]);
    points.push([center[0] + 100, center[1] + 100]); 
        
    //var coordinates = [[14097479.31202193, 4269696.333845764],
    //[14097479.31202193, 4291146.428300351],
    //[14111358.784904309, 4291146.428300351],
    //[14111358.784904309, 4269696.333845764]]; //좌표 설정
    
    var polygon_feature = new ol.Feature({
        geometry: new ol.geom.Polygon([points])
    }); // polygon_feature 생성

    var style = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(165, 42, 42, 0.2)'
        }),
        stroke: new ol.style.Stroke({
            color: '#ffcc33',
            width: 2
        }),
        image: new ol.style.Circle({
            radius: 7,
            fill: new ol.style.Fill({
                color: '#ffcc33'
            })
        })
    }); // 스타일 설정

    

    polygon_feature.setStyle(style);

    customLayerVector.getSource().addFeature(polygon_feature); 
}

loadCustomLayer();