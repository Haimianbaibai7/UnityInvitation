using System;
using System.Collections.Generic;

[Serializable]
public class InformationData
{
    public string Name;
    public string PhoneNember;
    public string CompanyOrSchool;
    public string Phase;
}


[Serializable]
public class InformationDataList
{
    public List<InformationData> DataList;
}