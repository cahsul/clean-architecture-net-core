
export function dashboardReady(obj) {

    var bars_basic = echarts.init(obj);

    // Options
    bars_basic.setOption({

        // Global text styles
        textStyle: {
            fontFamily: 'Roboto, Arial, Verdana, sans-serif',
            fontSize: 13
        },

        // Chart animation duration
        animationDuration: 750,

        // Setup grid
        grid: {
            left: 0,
            right: 30,
            top: 35,
            bottom: 0,
            containLabel: true
        },

        // Add legend
        legend: {
            data: ['Year 2013', 'Year 2014'],
            itemHeight: 8,
            itemGap: 20,
            textStyle: {
                padding: [0, 5]
            }
        },

        // Add tooltip
        tooltip: {
            trigger: 'axis',
            backgroundColor: 'rgba(0,0,0,0.75)',
            padding: [10, 15],
            textStyle: {
                fontSize: 13,
                fontFamily: 'Roboto, sans-serif',
                color: 'white'
            },
            axisPointer: {
                type: 'shadow',
                shadowStyle: {
                    color: 'rgba(0,0,0,0.025)'
                }
            }
        },

        // Horizontal axis
        xAxis: [{
            type: 'value',
            boundaryGap: [0, 0.01],
            axisLabel: {
                color: '#333'
            },
            axisLine: {
                lineStyle: {
                    color: '#999'
                }
            },
            splitLine: {
                show: true,
                lineStyle: {
                    color: '#eee',
                    type: 'dashed'
                }
            }
        }],

        // Vertical axis
        yAxis: [{
            type: 'category',
            data: ['Germany', 'France', 'Spain', 'Netherlands', 'Belgium'],
            axisLabel: {
                color: '#333'
            },
            axisLine: {
                lineStyle: {
                    color: '#999'
                }
            },
            splitLine: {
                show: true,
                lineStyle: {
                    color: ['#eee']
                }
            },
            splitArea: {
                show: true,
                areaStyle: {
                    color: ['rgba(250,250,250,0.1)', 'rgba(0,0,0,0.015)']
                }
            }
        }],

        // Add series
        series: [
            {
                name: 'Year 2013',
                type: 'bar',
                itemStyle: {
                    normal: {
                        color: '#EF5350'
                    }
                },
                data: [38203, 73489, 129034, 204970, 331744]
            },
            {
                name: 'Year 2014',
                type: 'bar',
                itemStyle: {
                    normal: {
                        color: '#66BB6A'
                    }
                },
                data: [39325, 83438, 131000, 221594, 334141]
            }
        ]
    });

    var triggerChartResize = function () {
        obj && bars_basic.resize();
    };

    // On sidebar width change
    var sidebarToggle = document.querySelectorAll('.sidebar-control');
    if (sidebarToggle) {
        sidebarToggle.forEach(function (togglers) {
            togglers.addEventListener('click', triggerChartResize);
        });
    }

    // On window resize
    var resizeCharts;
    window.addEventListener('resize', function () {
        clearTimeout(resizeCharts);
        resizeCharts = setTimeout(function () {
            triggerChartResize();
        }, 200);
    });

}

export function pieChart(obj) {

    var bars_basic = echarts.init(obj);

    // Options
    bars_basic.setOption({

        // Colors
        color: [
            '#2ec7c9', '#b6a2de', '#5ab1ef', '#ffb980', '#d87a80',
            '#8d98b3', '#e5cf0d', '#97b552', '#95706d', '#dc69aa',
            '#07a2a4', '#9a7fd1', '#588dd5', '#f5994e', '#c05050',
            '#59678c', '#c9ab00', '#7eb00a', '#6f5553', '#c14089'
        ],

        // Global text styles
        textStyle: {
            fontFamily: 'Roboto, Arial, Verdana, sans-serif',
            fontSize: 13
        },

        // Add title
        title: {
            text: 'Browser popularity',
            subtext: 'Open source information',
            left: 'center',
            textStyle: {
                fontSize: 17,
                fontWeight: 500
            },
            subtextStyle: {
                fontSize: 12
            }
        },

        // Add tooltip
        tooltip: {
            trigger: 'item',
            backgroundColor: 'rgba(0,0,0,0.75)',
            padding: [10, 15],
            textStyle: {
                fontSize: 13,
                fontFamily: 'Roboto, sans-serif'
            },
            formatter: "{a} <br/>{b}: {c} ({d}%)"
        },

        // Add legend
        legend: {
            orient: 'vertical',
            top: 'center',
            left: 0,
            data: ['IE', 'Opera', 'Safari', 'Firefox', 'Chrome'],
            itemHeight: 8,
            itemWidth: 8
        },

        // Add series
        series: [{
            name: 'Browsers',
            type: 'pie',
            radius: '70%',
            center: ['50%', '57.5%'],
            itemStyle: {
                normal: {
                    borderWidth: 1,
                    borderColor: '#fff'
                }
            },
            data: [
                { value: 335, name: 'IE' },
                { value: 310, name: 'Opera' },
                { value: 234, name: 'Safari' },
                { value: 135, name: 'Firefox' },
                { value: 1548, name: 'Chrome' }
            ]
        }]
    });


    var triggerChartResize = function () {
        obj && bars_basic.resize();
    };

    // On sidebar width change
    var sidebarToggle = document.querySelectorAll('.sidebar-control');
    if (sidebarToggle) {
        sidebarToggle.forEach(function (togglers) {
            togglers.addEventListener('click', triggerChartResize);
        });
    }

    // On window resize
    var resizeCharts;
    window.addEventListener('resize', function () {
        clearTimeout(resizeCharts);
        resizeCharts = setTimeout(function () {
            triggerChartResize();
        }, 200);
    });

}