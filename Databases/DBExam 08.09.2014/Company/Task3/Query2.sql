select Name, count(*) as [Employees Count] from Departmens 
inner join Employees
on Departmens.ID = Employees.DepartmentID
group by Departmens.Name
order by [Employees Count] desc