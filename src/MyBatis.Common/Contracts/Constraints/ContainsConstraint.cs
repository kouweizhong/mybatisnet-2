﻿
#region Apache Notice
/*****************************************************************************
 * $Revision: 387044 $
 * $LastChangedDate: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
 * $LastChangedBy: gbayon $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2008/2005 - The Apache Software Foundation
 *  
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 ********************************************************************************/
#endregion

namespace MyBatis.Common.Contracts.Constraints
{
    /// <summary>
    /// Checks that the string contains the specified string.
    /// </summary>
    public class ContainsConstraint: BaseConstraint
    {
        private readonly string expected = string.Empty;

        /// <summary>
         /// Initializes a new instance of the <see cref="ContainsConstraint"/> class.
        /// </summary>
         /// <param name="expected">The expected string.</param>
        public ContainsConstraint(string expected)
        {
            this.expected = expected;
        }

        /// <summary>
        /// Determines whether [is satisfied by] [the specified obj].
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="appendErrorMessage">The append error message.</param>
        /// <returns>
        /// 	<c>true</c> if [is satisfied by] [the specified obj]; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsSatisfiedBy(object actual, AppendErrorMessage appendErrorMessage)
        {
            bool test = ((actual != null) && (actual.ToString().IndexOf(expected) > -1));
            ErrorMessage = NegationMessage + "contains '" + expected + "'";

            if (!test)
            {
                //string not = test ? string.Empty : "not";
                appendErrorMessage(ErrorMessage);
            }

            return test;
        }
    }
}
