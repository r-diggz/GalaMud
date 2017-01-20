﻿/*
 * Created by SharpDevelop.
 * User: Aaron2
 * Date: 1/13/2017
 * Time: 7:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Mud.Characters;
namespace Mud.Actions
{
	/// <summary>
	/// Description of AttackAction.
	/// </summary>
	public class AttackAction : TargetedAction
	{
		public static ActionBuilder GetActionBuilder()
		{
			return new ActionBuilder("attack",
			                         (o)=>{return new AttackAction(o.Sender,o.Target);},
			                         false);
		}
		public AttackAction(MudCharacter Character,MudCharacter target):base(Character,target)
		{
			
		}
		public override string DoAction()
		{
			int dmg=Character.GetDamage();
			int dmgdone=Target.TakeDamage(dmg);
			return string.Format("{0} attacked {1} doing {2} damage ({3} damage absorbed by armor)",Character.Name,Target.Name,dmgdone,dmg-dmgdone);
		}
	}
}
