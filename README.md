# Simple Task Manager

This is a lightweight Task Manager application built using **C#** and **Visual Studio**. It provides users with the ability to monitor and manage currently running processes on their Windows system. The application also includes an option to restart the Windows Explorer process (`explorer.exe`), making it especially useful for troubleshooting issues with the Windows desktop environment.

---

## Features

- **Process Management**: View a list of currently running processes, their IDs, and memory usage.
- **End Processes**: Terminate any unresponsive or unnecessary processes.
- **Restart Windows Explorer**: Easily restart `explorer.exe` if your desktop or taskbar is behaving abnormally.
- **Dark Mode UI**: A clean and modern user interface with a dark theme and a visually appealing design.
- **Resizable Window**: Fully resizable layout to fit any screen size.

---

## Why I Created This

A while back, I encountered a recurring issue with my system where the **Windows Explorer** would frequently freeze, making it impossible to interact with the taskbar or desktop. This required me to open the default Windows Task Manager, locate `explorer.exe`, terminate it, and then manually restart it. While this workaround worked, I found it cumbersome to perform repeatedly.

Additionally, I wanted to create a simple but powerful tool that focused on process management without the complexity of the default Task Manager. This project was born as a practical solution to my problem, allowing me to handle unresponsive processes and quickly restart Windows Explorer with a single button click.

---

## How It Works

1. **Process Viewer**: The application uses the `System.Diagnostics` namespace to fetch and display all currently running processes.
   - A `DataGridView` displays the processes in a tabular format, including columns for Process Name, ID, and Memory Usage.

2. **End Process**: Selecting a process from the list and clicking the "End Process" button will terminate the selected process using the `Kill` method.

3. **Restart Explorer**: The "Restart Explorer" button is programmed to:
   - Locate all instances of `explorer.exe`.
   - Kill the process and wait for it to exit.
   - Restart `explorer.exe` to restore the Windows desktop environment.

4. **UI Enhancements**:
   - A dark mode theme with custom colors to provide a modern and visually pleasing experience.
   - Smooth resizing and adaptive layout to make the application user-friendly on any screen size.
   - Hover effects and selection highlights to improve usability.

---

## Technologies Used

- **Language**: C#
- **Framework**: .NET Framework
- **IDE**: Visual Studio
- **Windows Forms**: Used to design the UI and handle user interactions.

---

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/simple-task-manager.git
   cd simple-task-manager
   ```

2. Open the project in **Visual Studio**.

3. Build the project by pressing `Ctrl + Shift + B` or using the **Build** menu.

4. Run the application by pressing `F5` or clicking **Start** in Visual Studio.

---

## Screenshots

- **Main Interface**: Displays the list of currently running processes with a modern dark theme.
- **Restart Explorer Button**: A quick way to fix buggy desktop or taskbar behavior.

(Add screenshots here.)

---

## Lessons Learned

This project taught me several key concepts:

- How to interact with system processes using the `System.Diagnostics` namespace.
- Designing user-friendly and adaptive layouts with Windows Forms.
- The importance of providing tools for troubleshooting common system issues.

---

## Disclaimer

This application is intended for advanced users who understand the consequences of ending system processes. Terminating critical processes may lead to system instability.

---

## Future Improvements

- Add CPU and disk usage monitoring for each process.
- Implement search and filtering options for the process list.
- Support additional system management features, such as launching new processes.

---

## Conclusion

The Simple Task Manager is a lightweight and easy-to-use application that simplifies process management and provides a quick fix for buggy Windows Explorer behavior. It’s a practical solution for anyone who frequently deals with unresponsive processes or desktop issues. Give it a try, and feel free to contribute to the project by submitting feature suggestions or pull requests!

---

**GitHub Repository**: [https://github.com/yourusername/simple-task-manager](https://github.com/yourusername/simple-task-manager)

