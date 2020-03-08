# 集货位接口文档

[TOC]



> - ## 接口基地址

```xml
正式环境：http://{ServiceEndPoint}/interface/devices/
测试环境：http://192.168.3.5:8003/interface/devices/
<方法名+ResponseType>
<RequestStatus>返回状态(100为成功,其余均为失败)</RequestStatus>
<Msg>返回信息</Msg>
<Data>
	返回数据
</Data>
</方法名+ResponseType>
```

> - ### 公共参数

| 名称     | 类型   | 可空类型 | 示例值 | 描述     |
| -------- | ------ | -------- | ------ | -------- |
| stock_id | string | 必填     |        | 仓库id   |
| username | string | 必填     |        | 用户名   |
| password | string | 必填     |        | 用户密码 |

## **1、relay_picking/getMergePickingShelfCode(查询集货位)**

> - ### **请求参数**

| 名称   | 类型   | 可空类型 | 示例值 | 描述          |
| ------ | ------ | -------- | ------ | ------------- |
| number | string | 必填     |        | 集货位/周转箱 |

> - ### **响应参数说明和示例**

```xml
<getMergePickingShelfCodeResponseType>
    <RequestStatus>100</RequestStatus>
    <Msg></Msg>
    <Data>
    	<head>
            <task_no>任务编码</task_no>
            <shelf_code>集货位编码</shelf_code>
            <task_status>任务状态</task_status>
            <merge_picking_status>集货状态<merge_picking_status>
            <total_picing_count>总周转箱数</total_picing_count>
            <no_picing_count>待周转箱数</no_picing_count>
    	</head>
    	<details>
            <item>
                <trun_box>周转箱编码</trun_box>
                <trun_box_status>状态</trun_box_status>
            </item>
            <item>
                <trun_box>周转箱编码</trun_box>
                <trun_box_status>状态</trun_box_status>
            </item>
    	</details>
    </Data>
    </RequestStatus>
</getMergePickingShelfCodeResponseType>
```

## **2、relay_picking/getMergePickingShelfCode(查询集货位)**

> - ### **请求参数**

| 名称   | 类型   | 可空类型 | 示例值 | 描述          |
| ------ | ------ | -------- | ------ | ------------- |
| number | string | 必填     |        | 集货位/周转箱 |

> - ### **响应参数说明和示例**

```xml
<getMergePickingShelfCodeResponseType>
    <RequestStatus>100</RequestStatus>
    <Msg></Msg>
    <Data>
    	<head>
            <task_no>任务编码</task_no>
            <shelf_code>集货位编码</shelf_code>
            <task_status>任务状态</task_status>
            <merge_picking_status>集货状态<merge_picking_status>
            <total_picing_count>总周转箱数</total_picing_count>
            <no_picing_count>待周转箱数</no_picing_count>
    	</head>
    	<details>
            <item>
                <trun_box>周转箱编码</trun_box>
                <trun_box_status>状态</trun_box_status>
            </item>
            <item>
                <trun_box>周转箱编码</trun_box>
                <trun_box_status>状态</trun_box_status>
            </item>
    	</details>
    </Data>
    </RequestStatus>
</getMergePickingShelfCodeResponseType>
```

