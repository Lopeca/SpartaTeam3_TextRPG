using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 선택지는 자기가 출력될 이름과 출력될 함수가 기본
 public interface ISelectable
 {
    public string Name { get; }
    public void ActBySelect();
 }
