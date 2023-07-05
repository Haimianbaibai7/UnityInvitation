using System;
using System.Collections.Generic;

[Serializable]
public class InformationData
{
    public string Name;
    public string PhoneNumber;
    public string CompanyOrSchool;
    public string Phase;
}


[Serializable]
public class InformationDataList
{
    public List<InformationData> DataList;
}