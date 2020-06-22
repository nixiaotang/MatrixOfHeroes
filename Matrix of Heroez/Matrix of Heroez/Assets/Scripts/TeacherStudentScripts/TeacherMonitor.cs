using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacherMonitor : MonoBehaviour
{

    [SerializeField] Text teacherName;
    [SerializeField] GameObject studentInfo;

    private GameObject newObj;

    private int y = -60;


    void Start() {

        teacherName.text = GameManager.teacher.teacherName;

        foreach(var student in GameManager.teacher.students) {

            newObj = Instantiate(studentInfo);
            newObj.transform.SetParent(GameObject.FindWithTag("StudentInfo").transform);
            newObj.transform.localPosition = new Vector3(200, y, 0);

            newObj.transform.localScale = new Vector3(1, 1, 1);

            newObj.GetComponent<StudentInfo>().InfoUpdate(student.username, student.progress);

            y -= 60;
        }

        
    }

}
