﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
#if !NET_COREAPP
using System.Security.Permissions;
using System.Runtime.Serialization;
#endif

namespace DynamicExpresso
{
#if !NET_COREAPP
    [Serializable]
#endif
    public class AssignmentOperatorDisabledException : ParseException
	{
        public string OperatorString { get; private set; }

        public AssignmentOperatorDisabledException(string operatorString, int position)
			: base(string.Format("Assignment operator '{0}' not allowed", operatorString), position) 
		{
			OperatorString = operatorString;
		}

#if !NET_COREAPP
        protected AssignmentOperatorDisabledException(
			SerializationInfo info,
			StreamingContext context)
			: base(info, context) 
		{
			OperatorString = info.GetString("OperatorString");
		}

		[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("OperatorString", OperatorString);

			base.GetObjectData(info, context);
		}
#endif
    }

}
